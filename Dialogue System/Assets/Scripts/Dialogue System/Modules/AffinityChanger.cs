using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AffinityChanger : MonoBehaviour
{
    [SerializeField]    private string[] characterAffinity;

    private void Awake()
    {
        ChoiceController.executeChoice += UpdateAffinity;
        DialogueTrigger.endConversation += ClearAffinity;
    }

    public void UpdateAffinity(int index)
    {
        FindObjectOfType<GameManager>().UpdateAffinity(characterAffinity[index]);
    }

    public void ClearAffinity()
    {
        ChoiceController.executeChoice -= UpdateAffinity;
        DialogueTrigger.endConversation -= ClearAffinity;
    }
}
