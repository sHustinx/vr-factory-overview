using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CubeBehaviour : MonoBehaviour
{
    public GameObject cube;
    public GameObject cubeParent;

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
            if (ReturnClickedObject(out hitInfo).tag != "cube") // only spawn, if not dragging object
            {
                Debug.Log(ReturnClickedObject(out hitInfo).tag);
                SpawnPrefab();
            }
                
        }
    }

    void SpawnPrefab()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 8.0f;       // todo: calc autom. ?
        Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);

        GameObject tmp = Instantiate(cube, cubeParent.transform, true);     //, objectPos, Quaternion.identity,
        tmp.gameObject.transform.position = objectPos;

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






