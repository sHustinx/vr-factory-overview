using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 

public class WorkspaceOrderHandler : MonoBehaviour
{
    public Order[] orders;
    public GameObject nextWorkspace;
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

    public void passOrder(Order order){
        orders = orders.Where(i => i != order).ToArray();
        refreshOrders();
        nextWorkspace.GetComponent<WorkspaceOrderHandler>().receiveOrder(order);
    }

    public void receiveOrder(Order order){

    }

    public void refreshOrders(){

    }
}
