using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FloorplanManager : MonoBehaviour
{

    public GameObject infoPanel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            GameObject target = ReturnClickedObject(out hitInfo);
            if (target.tag == "cube")
            {
                WorkspaceInfo info = target.GetComponent<WorkspaceInfo>();
                //Debug.Log(info.id + " " + info.workspaceName + " " + info.description);
                info.SetStatus(WorkspaceInfo.WorkspaceStatus.Active);
                infoPanel.SetActive(true);
                infoPanel.GetComponent<UpdateDetailView>().InitializeText(info);
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






