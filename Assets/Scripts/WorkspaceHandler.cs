using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkspaceHandler : MonoBehaviour
{
    private GameObject statusCanvas;
    private GameObject detailCanvas;
    public GameObject DetailOverlay;
    // Start is called before the first frame update
    void Start()
    {
        statusCanvas = transform.Find("statusCanvas").gameObject;
        detailCanvas = transform.Find("detailCanvas").gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            var target = ReturnClickedObject(out hitInfo);
            float goalRotation = 0;
            Debug.Log(target.transform.tag);
            if (target == gameObject)
            {
                ToggleUICanvas();

                if ((int)target.transform.localRotation.eulerAngles.z == 180)
                    goalRotation = 0;
                else if ((int)target.transform.localRotation.eulerAngles.z == 0)
                    goalRotation = 180;

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
