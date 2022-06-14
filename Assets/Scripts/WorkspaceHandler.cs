using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkspaceHandler : MonoBehaviour
{
    private GameObject statusCanvas;
    private GameObject detailCanvas;

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
            if (target == gameObject) 
            { 
                transform.Rotate(0,0,180);
                ToggleUICanvas();
                
            }
        }
   

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
