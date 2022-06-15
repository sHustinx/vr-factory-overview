using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 
using UnityEngine.UI;
public class Zoom : MonoBehaviour, IPointerClickHandler
{
    public GameObject mainCam;
    private bool zoomed = false;
    private GameObject myParent;

    public bool GetZoomed(){
        return zoomed;
    }
    
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
        gameObject.GetComponent<RawImage>().enabled = false;
        ToggleChildren(false);
    }

    private void ZoomOut(){
        mainCam.transform.position = new Vector3(0,20,0);
        mainCam.GetComponent<Camera>().orthographicSize = 12;
        zoomed = false;                    
        gameObject.GetComponent<RawImage>().enabled = true;
        ToggleChildren(true);
    }


    private void ToggleChildren(bool active){
        
        foreach (Transform child in myParent.transform.parent.gameObject.transform){
            if(child.gameObject != myParent){
                child.gameObject.SetActive(active);
            }
        }
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
             }
             else
             {
                    ZoomOut();
             }
     }
}
