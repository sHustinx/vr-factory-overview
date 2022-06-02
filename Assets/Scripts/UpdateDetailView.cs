using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpdateDetailView : MonoBehaviour
{
    public TextMeshProUGUI nameField;
    public Button closeButton;


    // Start is called before the first frame update
    void Start()
    {
        closeButton.onClick.AddListener(TaskOnClick);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        gameObject.SetActive(false);
    }

    public void InitializeText(WorkspaceInfo info)
    {
        nameField.text = info.workspaceName;
    }

}
