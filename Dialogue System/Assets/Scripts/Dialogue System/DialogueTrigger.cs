using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject convoInit;       // First conversation of the Scene.
    private GameObject convoActive;     // Active Conversation.
    private Dialogue dialogue;          // Class containing dialogue content. DialogueContent is used to pass this information from the template to Trigger.
    
    void Start()
    {
        StartConvo(convoInit);       // Set initial choices for conversation.
    }

    public delegate void StartConversation(Dialogue dialogue);
    public static StartConversation startConversation;

    public delegate void EndConversation();
    public static EndConversation endConversation;

    private void Awake()
    {
        ChoiceController.executeChoice += DestroyActiveConversation;
    }

    public void StartConvo (GameObject convo)
    {
        convoActive = Instantiate(convo);
        startConversation?.Invoke(convoActive.GetComponent<DialogueContent>().dialogue);
    }

    private void DestroyActiveConversation(int choice)
    {
        Destroy(convoActive);
    }
}
