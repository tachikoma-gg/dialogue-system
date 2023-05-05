using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject convoInit;            // First conversation of the Scene.
    private Dialogue dialogue;              // Class containing dialogue content. DialogueContent is used to pass this information from the template to Trigger.

    private CharacterManager charaManager;  // Class that loads in the characters.
    private CharacterLoader charaLoader;    // Contains all of the Characters.

    void Awake()
    {
        // Load Managers
        charaManager = GameObject.Find("Character Manager").GetComponent<CharacterManager>();
    }

    void Start()
    {
        StartConvo(convoInit);       // Set initial choices for conversation.
    }

    // Display Correct number of choices, based on Dialogue content.
    public void StartConvo (GameObject convo)
    {
        dialogue = convo.GetComponent<DialogueContent>().dialogue;      // Get components of the conversation.

        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);    // Start conversation text.
        charaManager.SetSpeaker(dialogue.speaker);                      // Set who is currently speaking.
        
        // Set expressions.
        charaManager.SetExpression(dialogue.expression);
    }

    public string[] Choices()
    {
        string[] choices;
        choices = dialogue.choices;
        return choices;
    }
}
