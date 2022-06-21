using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 
public class WorkspaceOrderHandler : MonoBehaviour
{
    public List<Order> orders {get; set;}
    public GameObject prevWorkspace = null;
    public GameObject nextWorkspace = null;
    
    void Awake(){

      orders = new List<Order>();
    }


    public void SetOrders(List<Order> activeOrders){
        orders = new List<Order>();
        if(activeOrders.Count() > 0){
            orders.AddRange(activeOrders);
        }
        refreshOrders();
    }

    public void passOrder(Order order, bool forward){
        Debug.Log("pass!");
        orders = orders.Where(i => i != order).ToList();
        refreshOrders();
        if(forward){
            nextWorkspace.GetComponent<WorkspaceOrderHandler>().receiveOrder(order);
        }
        else{
            nextWorkspace.GetComponent<WorkspaceOrderHandler>().receiveOrder(order);
        }
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

    public void UpdateOrders(bool forward){
        if(forward){
            if(nextWorkspace != null){
                Debug.Log(orders.Count());
                foreach(Order o in orders){
                    passOrder(o, forward);
                }
            }
        }
        else{
            if(prevWorkspace != null){
                foreach(Order o in orders){
                    passOrder(o, forward);
                }
            }
        }
    }
}
