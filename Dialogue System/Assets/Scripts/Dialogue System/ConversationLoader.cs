using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationLoader : MonoBehaviour
{
    public GameObject[] outcomes;   // Convo Catalogs for conversations following choice.

    public void ChooseConversation(int choice)
    {
        DialogueTrigger dialogueTrigger = FindObjectOfType<DialogueTrigger>().GetComponent<DialogueTrigger>();
        dialogueTrigger.StartConvo(outcomes[choice]);
    }
}
