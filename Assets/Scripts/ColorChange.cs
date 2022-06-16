using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;


public class ColorChange : MonoBehaviour
{

    private MachineStatus status;

    public enum MachineStatus
    {
        OnTrack,
        SlightDelay,
        BigDelay
    }

    public void SetStatus(MachineStatus value)
    {
         status = value;
         //update color
         switch (value)
         {
             case MachineStatus.OnTrack:
                 gameObject.GetComponent<Renderer>().material.color = Color.green;
                 break;
             case MachineStatus.SlightDelay:
                 gameObject.GetComponent<Renderer>().material.color = Color.yellow;
                 break;
             case MachineStatus.BigDelay:
                 gameObject.GetComponent<Renderer>().material.color = Color.red;
                 break;
         }
    }

    public MachineStatus GetStatus()
    {
        return status;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetStatus(MachineStatus.OnTrack);
        StartCoroutine(UpdateStatus());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator UpdateStatus()
    {
        while (true)
        {
            int rand = Range(0, 100);

            if (rand < 100) //25%
            {
                SetStatus(MachineStatus.OnTrack);
            }
            if (rand < 15) //23%
            {
                SetStatus(MachineStatus.SlightDelay);
            }
            if (rand < 5) //23%
            {
                SetStatus(MachineStatus.BigDelay);
            }

            yield return new WaitForSeconds(10.0f);
        }

    }
}
