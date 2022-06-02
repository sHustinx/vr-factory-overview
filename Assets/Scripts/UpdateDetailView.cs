using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateDetailView : MonoBehaviour
{
    public TextMeshProUGUI nameField;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitializeText(WorkspaceInfo info)
    {
        nameField.text = info.workspaceName;
    }

}
