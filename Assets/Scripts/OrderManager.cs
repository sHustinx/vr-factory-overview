using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class OrderManager : MonoBehaviour
{
    public List<Company> companies;
    public GameObject workSpaces;

    public bool filtered = false;
    public List<Company> filteredCompanies;

    void Start(){
        Color colorC1 = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        Company c1 = new Company{
            name = "SPS",
            color = colorC1,
            orders = new List<Order>{
                new Order{
                    code = "0517382135",
                    color = colorC1,
                    initialMachine = 0
                },
                new Order{
                    code = "8510923812",
                    color = colorC1,
                    initialMachine = 0
                },
                new Order{
                    code = "7620423563",
                    color = colorC1,
                    initialMachine = 3
                }
            }
        };
        
        
        Color colorC2 = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        Company c2 = new Company{
            name = "Delwi Groenink",
            color = colorC2,
            orders = new List<Order>{
                new Order{
                    code = "7921308135",
                    color = colorC2,
                    initialMachine = 0
                },
                new Order{
                    code = "6382197312",
                    color = colorC2,
                    initialMachine = 1
                },
                new Order{
                    code = "3517302159",
                    color = colorC2,
                    initialMachine = 2
                }
            }
        };
        
        
        
        Color colorC3 = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        Company c3 = new Company{
            name = "University of Twente",
            color = colorC3,
            orders = new List<Order>{
                new Order{
                    code = "7921308135",
                    color = colorC3,
                    initialMachine = 1
                },
                new Order{
                    code = "6382197312",
                    color = colorC3,
                    initialMachine = 4
                },
                new Order{
                    code = "1571322855",
                    color = colorC3,                  
                    initialMachine = 3
                }
            }
        };
        companies = new List<Company>{c1,c2,c3};
        SetOrders();
    }

    public void SetOrders(){
        int i = 0;
        foreach(Transform workSpace in workSpaces.transform){
            Transform orderScreen = workSpace.Find("productionCanvas");
            Transform orderList = orderScreen.Find("Projects");

            foreach(Transform order in orderList){
                order.gameObject.SetActive(false);
                    
            }

            List<Company> cList;
            if (filtered){
                cList = filteredCompanies.Where(c => 
                c.orders.Any(o =>
                    o.initialMachine == i)
                ).ToList();
            }
            else{
                cList = companies.Where(c => 
                c.orders.Any(o =>
                    o.initialMachine == i)
                ).ToList();
            }

            List<Order> activeOrders = new List<Order>();
            foreach(Company c in cList){
                activeOrders.AddRange(c.orders.Where(o => o.initialMachine == i).ToList());
            }
            
            WorkspaceOrderHandler handler = orderList.GetComponent<WorkspaceOrderHandler>();
            handler.SetOrders(activeOrders);
            i++;
        }
    }

    public void UpdateOrders(bool forward){
        
        List<List<Order>> oldList = new List<List<Order>>();
        foreach(Transform workSpace in workSpaces.transform){			
            
            Transform orderScreen = workSpace.Find("productionCanvas");
            Transform orderList = orderScreen.Find("Projects");

            WorkspaceOrderHandler handler = orderList.GetComponent<WorkspaceOrderHandler>();
            //handler.UpdateOrders(forward);
            oldList.Add(handler.orders);
        }
        List<List<Order>> newList = new List<List<Order>>();
        if(forward){
            newList.Add(oldList[5]);
            for(int i = 0; i<oldList.Count()-1; i++){
                newList.Add(oldList[i]);
                Debug.Log(i);
            }
        }
        else{
            for(int j = 0; j<oldList.Count()-1; j++){
                newList.Add(oldList[j+1]);
            }
            newList.Add(oldList[0]);
        }
        Debug.Log(newList.Count());
        int k = 0;
        foreach(Transform workSpace in workSpaces.transform){			
            
            Transform orderScreen = workSpace.Find("productionCanvas");
            Transform orderList = orderScreen.Find("Projects");

            WorkspaceOrderHandler handler = orderList.GetComponent<WorkspaceOrderHandler>();
            handler.SetOrders(newList[k]);
            k++;

        }
    }
}

