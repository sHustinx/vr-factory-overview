using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WorkspaceInfo : MonoBehaviour
{
    public int id;
    public string workspaceName;
    public string description;
    public WorkspaceStatus status;

    public GameObject clock_green;
    public GameObject clock_orange;
    public GameObject clock_red;

    public GameObject jobs_green;
    public GameObject jobs_orange;
    public GameObject jobs_red;

    public GameObject delay_green;
    public GameObject delay_orange;
    public GameObject delay_red;

    public TextMeshProUGUI workspaceTitle;
    public TextMeshProUGUI detailTitle;

    public float numOfDelays = 5;
    public float numOfJobs = 5;
    public float numOfPredictedDelays = 5;


    public enum WorkspaceStatus
    {
        Active,
        Inactive,
        OutOfOrder
    }

    public void SetStatus(WorkspaceStatus value)
    {
        // status = value;

        // //update color
        // switch (value)
        // {
        //     case WorkspaceStatus.Active:
        //         gameObject.GetComponent<Renderer>().material.color = Color.green;
        //         break;
        //     case WorkspaceStatus.Inactive:
        //         gameObject.GetComponent<Renderer>().material.color = Color.grey;
        //         break;
        //     case WorkspaceStatus.OutOfOrder:
        //         gameObject.GetComponent<Renderer>().material.color = Color.red;
        //         break;
        // }
    }

    public WorkspaceStatus GetStatus()
    {
        return status;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetStatus(WorkspaceStatus.Inactive);

        clock_red.SetActive(false);
        clock_green.SetActive(true);
        clock_orange.SetActive(false);

        jobs_red.SetActive(false);
        jobs_green.SetActive(true);
        jobs_orange.SetActive(false);

        delay_red.SetActive(false);
        delay_green.SetActive(true);
        delay_orange.SetActive(false);

        StartCoroutine(UpdateValues());

        
        workspaceTitle.text = workspaceName;
        detailTitle.text = workspaceName;

    }

    // Update is called once per frame
    void Update()
    {

        if (numOfDelays < 5)
        {
            clock_red.SetActive(false);
            clock_green.SetActive(true);
            clock_orange.SetActive(false);
        }
        if (numOfDelays > 5)
        {
            clock_red.SetActive(false);
            clock_green.SetActive(false);
            clock_orange.SetActive(true);
        }
        if (numOfDelays > 10)
        {
            clock_red.SetActive(true);
            clock_green.SetActive(false);
            clock_orange.SetActive(false);
        }


        if (numOfJobs < 5)
        {
            jobs_red.SetActive(false);
            jobs_green.SetActive(true);
            jobs_orange.SetActive(false);
        }
        if (numOfJobs > 5)
        {
            jobs_red.SetActive(false);
            jobs_green.SetActive(false);
            jobs_orange.SetActive(true);
        }
        if (numOfJobs > 10)
        {
            jobs_red.SetActive(true);
            jobs_green.SetActive(false);
            jobs_orange.SetActive(false);
        }

        if (numOfPredictedDelays < 5)
        {
            delay_red.SetActive(false);
            delay_green.SetActive(true);
            delay_orange.SetActive(false);
        }
        if (numOfPredictedDelays > 5)
        {
            delay_red.SetActive(false);
            delay_green.SetActive(false);
            delay_orange.SetActive(true);
        }
        if (numOfPredictedDelays > 10)
        {
            delay_red.SetActive(true);
            delay_green.SetActive(false);
            delay_orange.SetActive(false);
        }
    }

    IEnumerator UpdateValues()
    {
        while (true)
        {
            numOfDelays = numOfDelays + Random.Range(-0.5f, 0.5f);
            numOfJobs = numOfJobs + Random.Range(-0.5f, 0.5f);
            numOfPredictedDelays = numOfPredictedDelays + Random.Range(-0.5f, 0.5f);
            yield return new WaitForSeconds(2.0f);
        }
        
    }


}
