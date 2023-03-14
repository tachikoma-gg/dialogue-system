using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceMaker : MonoBehaviour
{
    private DialogueTrigger dialogueTrigger;
    
    public void Choose(int choice)
    {
        dialogueTrigger.Choose(choice);
    }

    public void LoadDialogueTrigger()
    {
        Debug.Log("Load Dialogue Triggers");
        dialogueTrigger = null;
        dialogueTrigger = GameObject.Find("Convo Catalog").GetComponent<DialogueTrigger>();
    }
}
