using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 

public class Zoom : MonoBehaviour, IPointerClickHandler
{
    public GameObject mainCam;
    private bool zoomed = false;
    private GameObject myParent;

    public void Start(){
        myParent = transform.parent.gameObject.transform.parent.gameObject;
    }

    public void Update() {
        if(zoomed && Input.GetMouseButtonDown(0))
        {
            HideIfClickedOutside(myParent);
        }
    }
 
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        mainCam.transform.position = new Vector3(myParent.transform.position.x, 20, myParent.transform.position.z);
        mainCam.GetComponent<Camera>().orthographicSize = 4;
        zoomed = true;
    }

    private void ZoomOut(){
        mainCam.transform.position = new Vector3(0,20,0);
        mainCam.GetComponent<Camera>().orthographicSize = 12;
        zoomed = false;            
    }

    private void HideIfClickedOutside(GameObject panel) {
            RaycastHit hit = new RaycastHit();      
            Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
 
             if (Physics.Raycast(ray, out hit))
             {
                 if (hit.transform.tag == "Floor")
                 {
                    ZoomOut();
                 }
                 else
                 {
                     Debug.Log("Click somewhere else");
                 }
             }
             else
             {
                    ZoomOut();
             }
     }
}
