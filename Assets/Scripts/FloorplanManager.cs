using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorplanManager : MonoBehaviour
{

    public GameObject infoPanel;
    public Button processView;
    public Button machineView;
    private ViewState viewState;

    enum ViewState
    {
        Machines,
        Process,
        Product
    }

    // Start is called before the first frame update
    void Start()
    {
        processView.onClick.AddListener(SetProcessView);
        machineView.onClick.AddListener(SetMachineView);
    }

    void SetProcessView()
    {
        viewState = ViewState.Process;
    }

    void SetMachineView()
    {
        viewState = ViewState.Machines;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            GameObject target = ReturnClickedObject(out hitInfo);
            Debug.Log(target);
            if (target != null && target.tag == "cube")
            {
                if (!infoPanel.activeSelf)
                {

                    WorkspaceInfo info = target.GetComponent<WorkspaceInfo>();
                    info.SetStatus(WorkspaceInfo.WorkspaceStatus.Active);

                    switch (viewState)
                    {
                        case ViewState.Machines:
                            Debug.Log("Macihne view");
                            infoPanel.SetActive(true);
                            infoPanel.GetComponent<UpdateDetailView>().InitializeText(info);
                            break;
                        case ViewState.Process:
                            Debug.Log("Process view");
                            infoPanel.SetActive(true);
                            infoPanel.GetComponent<UpdateDetailView>().InitializeText(info);
                            break;
                    }
                }
                
            }



        }
    }

    /*void SpawnPrefab()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 8.0f;       // todo: calc autom. ?
        Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);

        GameObject tmp = Instantiate(cube, cubeParent.transform, true);     //, objectPos, Quaternion.identity,
        tmp.gameObject.transform.position = objectPos;

    }*/

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






