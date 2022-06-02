using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkspaceInfo : MonoBehaviour
{
    public int id;
    public string workspaceName;
    public string description;
    public WorkspaceStatus status;


    public enum WorkspaceStatus
    {
        Active,
        Inactive,
        OutOfOrder
    }

    public void SetStatus(WorkspaceStatus value)
    {
        status = value;

        //update color
        switch (value)
        {
            case WorkspaceStatus.Active:
                gameObject.GetComponent<Renderer>().material.color = Color.green;
                break;
            case WorkspaceStatus.Inactive:
                gameObject.GetComponent<Renderer>().material.color = Color.grey;
                break;
            case WorkspaceStatus.OutOfOrder:
                gameObject.GetComponent<Renderer>().material.color = Color.red;
                break;
        }
    }

    public WorkspaceStatus GetStatus()
    {
        return status;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetStatus(WorkspaceStatus.Inactive);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
