using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationLoader : MonoBehaviour
{
    [SerializeField]    private GameObject[] outcomes;   // Convo Catalogs for conversations following choice.

    private void Awake()
    {
        ChoiceController.executeChoice += ChooseConversation;
        DialogueTrigger.endConversation += ClearChooseConversation;
    }

    public void ChooseConversation(int choice)
    {
        FindObjectOfType<ChoiceLoader>().EnableChoies();
        FindObjectOfType<DialogueTrigger>().StartConvo(outcomes[choice]);
    }

    public void ClearChooseConversation()
    {
        ChoiceController.executeChoice -= ChooseConversation;
        DialogueTrigger.endConversation -= ClearChooseConversation;
    }
}
