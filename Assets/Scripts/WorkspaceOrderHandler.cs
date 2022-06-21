using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 

public class WorkspaceOrderHandler : MonoBehaviour
{
    public List<Order> orders;
    public GameObject nextWorkspace;
    // Start is called before the first frame update
    void Start()
    {
        orders = new List<Order>();

        int children = transform.childCount;
         for (int i = 0; i < children; ++i){
             transform.GetChild(i).GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
         }
    }


    public void passOrder(Order order){
        orders = orders.Where(i => i != order).ToList();
        refreshOrders();
        nextWorkspace.GetComponent<WorkspaceOrderHandler>().receiveOrder(order);
    }

    public void receiveOrder(Order order){
        orders.Add(order);
        refreshOrders();
    }

    public void refreshOrders(){
        for (int a = 0; a < transform.childCount; a++)
        {
            transform.GetChild(a).gameObject.SetActive(false);
        }
        int i = 0;
        foreach(Order o in orders){            
            transform.GetChild(i).gameObject.SetActive(true);

            transform.GetChild(i).GetComponent<Renderer>().material.color = o.color;
            i++;
        }
    }
}
