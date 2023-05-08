using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationLoader : MonoBehaviour
{
    [SerializeField]    private GameObject[] outcomes;   // Convo Catalogs for conversations following choice.

    public void ChooseConversation(int choice)
    {
        FindObjectOfType<ChoiceLoader>().EnableChoies();
        FindObjectOfType<DialogueTrigger>().StartConvo(outcomes[choice]);
    }
}
