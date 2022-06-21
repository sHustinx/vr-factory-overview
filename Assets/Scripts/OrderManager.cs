using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    List<Company> companies;
    void Start(){
        Color colorC1 = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        Company c1 = new Company{
            name = "SPS",
            color = colorC1,
            orders = new List<Order>{
                new Order{
                    code = "1234567890",
                    color = colorC1
                },
                new Order{
                    code = "0987654321",
                    color = colorC1
                }
            }
        };
    }
}
