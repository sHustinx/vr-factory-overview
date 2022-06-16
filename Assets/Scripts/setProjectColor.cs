using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setProjectColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int children = transform.childCount;
         for (int i = 0; i < children; ++i){
             transform.GetChild(i).GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
         }
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
