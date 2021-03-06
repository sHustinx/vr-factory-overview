using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WorkspaceHandler : MonoBehaviour
{
    private GameObject statusCanvas;
    private GameObject detailCanvas;
    public GameObject DetailOverlay;

    public TextMeshProUGUI sidebarTitle;
    public TextMeshProUGUI sidebarSubTitle;
    public GameObject sidebarContent;

    private FloorplanManager FloorplanManager;
    // Start is called before the first frame update
    void Start()
    {
        statusCanvas = transform.Find("statusCanvas").gameObject;
        detailCanvas = transform.Find("detailCanvas").gameObject;
        FloorplanManager = GameObject.Find("Scripts").GetComponent<FloorplanManager>();
        //sidebarTitle.text = "test";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && FloorplanManager.getViewState() == FloorplanManager.ViewState.Machines)
        {
            RaycastHit hitInfo;
            var target = ReturnClickedObject(out hitInfo);
            float goalRotation = 0;

            if (target == null) //prevent crashes
                return;
            if (target == gameObject)
            {
                ToggleUICanvas();

                if ((int)target.transform.localRotation.eulerAngles.z == 180)
                    goalRotation = 0;
                else if ((int)target.transform.localRotation.eulerAngles.z == 0)
                    goalRotation = 180;

                if (sidebarContent.activeSelf == false)
                    sidebarContent.SetActive(true);
                sidebarTitle.text = target.GetComponent<WorkspaceInfo>().workspaceName;
                sidebarSubTitle.text = target.GetComponent<WorkspaceInfo>().description;
                StartCoroutine(Rotate(target, goalRotation));
            }
            else if(target.transform.tag == "machine"){
                DetailOverlay.SetActive(true);
            }
        }


        
    }

    IEnumerator Rotate(GameObject target, float goalRotation)
    {
        if (goalRotation == 0)
        {
            while (target.transform.localRotation.eulerAngles.z >= goalRotation)
            {
                target.transform.Rotate(Vector3.forward, -10);
                yield return new WaitForSeconds(0.01f);
            }
        }
        else
        {
            while (target.transform.localRotation.eulerAngles.z <= goalRotation)
            {
                target.transform.Rotate(Vector3.forward, 10);
                yield return new WaitForSeconds(0.01f);
            }
        }
        

        /*Vector3 targetAngles = target.transform.eulerAngles + 180f * Vector3.forward; // what the new angles should be

        transform.eulerAngles = Vector3.Lerp(target.transform.eulerAngles, targetAngles, Time.deltaTime); // lerp to new angles
        yield return new WaitForSeconds(0.01f);*/
        yield return null;
    }

    void ToggleUICanvas(){
        statusCanvas.SetActive(!statusCanvas.activeSelf);
        detailCanvas.SetActive(!detailCanvas.activeSelf);
    }

    GameObject ReturnClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            target = hit.collider.gameObject;
        }
        return target;
    }
}
