using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FloorplanManager : MonoBehaviour
{

    public GameObject infoPanel;
    public Button processView;
    public Button machineView;
    public GameObject detailSidebar;
    public GameObject processSidebar;

    private ViewState viewState;
    private GameObject connections;
    private bool linesRendered = false;
    private LineRenderer lr;

    public GameObject machines;

    public TMP_Dropdown clientSelection;
    public TMP_Dropdown productSelection;


    public enum ViewState
    {
        Machines,
        Process,
        Product
    }

    // Start is called before the first frame update
    void Start()
    {
        machines = GameObject.Find("Machines");
        processView.onClick.AddListener(SetProcessView);
        machineView.onClick.AddListener(SetMachineView);
        connections = new GameObject("LineRenderer");

        List<string> options = new List<string> { "Option 1", "Option 2"};
        updateDropdown(clientSelection, options);
    }

    void updateDropdown(TMP_Dropdown dropdown, List<string> optionlist){
        dropdown.ClearOptions();
        dropdown.AddOptions(optionlist);   
    }

    public ViewState getViewState(){
        return viewState;
    }

    void SetProcessView()
    {
        detailSidebar.SetActive(false);
        processSidebar.SetActive(true);

        resetMachines(machines);
        viewState = ViewState.Process;
        ShowConnections();
        infoPanel.SetActive(false);


        int children = machines.transform.childCount;
        for (int i = 0; i < children; ++i)
        {
            machines.transform.GetChild(i).transform.Find("productionCanvas").gameObject.SetActive(true);
            machines.transform.GetChild(i).transform.Find("statusCanvas").gameObject.SetActive(false);
        }
            
    }

    void SetMachineView()
    {
        detailSidebar.SetActive(true);
        processSidebar.SetActive(false);

        viewState = ViewState.Machines;

        if (connections.activeSelf)
            connections.SetActive(false);

        int children = machines.transform.childCount;
        for (int i = 0; i < children; ++i)
        {
            machines.transform.GetChild(i).transform.Find("productionCanvas").gameObject.SetActive(false);
            machines.transform.GetChild(i).transform.Find("statusCanvas").gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            GameObject target = ReturnClickedObject(out hitInfo);
            //Debug.Log(target);
            if (target != null && target.tag == "cube")
            {
                if (!infoPanel.activeSelf)
                {

                    WorkspaceInfo info = target.GetComponent<WorkspaceInfo>();
                    info.SetStatus(WorkspaceInfo.WorkspaceStatus.Active);

                    switch (viewState)
                    {
                        case ViewState.Machines:
                            Debug.Log("Machine view");
                            infoPanel.SetActive(true);
                            infoPanel.GetComponent<UpdateDetailView>().InitializeText(info);
                            break;
                        case ViewState.Process:
                            Debug.Log("Process view");
                            break;
                    }
                }
                
            }



        }
    }

    void resetMachines(GameObject machineParent)
    {
        int children = machines.transform.childCount;
        for (int i = 0; i < children; ++i)
        {
            machines.transform.GetChild(i).transform.rotation = Quaternion.Euler(0,0,0);
        }
    }

    //for process view, show connections between machines
    void ShowConnections()
    {
        if (!linesRendered)
        {
            
            lr = connections.AddComponent<LineRenderer>();

            var parent = GameObject.Find("Machines");
            lr.positionCount = parent.transform.childCount;

            for (int i = 0; i < parent.transform.childCount; i++)
            {
                lr.SetPosition(i, parent.transform.GetChild(i).gameObject.transform.position);
            }

            Color c1 = Color.white;
            Color c2 = new Color(1, 1, 1, 0.2f);
            lr.material = new Material(Shader.Find("Sprites/Default"));
            lr.startColor = c1;
            lr.endColor = c2;
            lr.startWidth = 0.6f;
            lr.endWidth = 0.4f;


            linesRendered = true;
        }
        else
        {
            connections.SetActive(true);
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






