using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject convo;                // First conversation of the Scene.
    private Dialogue dialogue;              // Class containing dialogue content. DialogueContent is used to pass this information from the template to Trigger.

    private GameObject[] choices;            // Choices Button GameObject from Scene.
    private GameObject[] choicesText;        // Choices text to be displayed on buttons.
    private GameObject[] outcomes;           // Conversation set corresponding to each choice.

    private CharacterManager charaManager;  // Class that loads in the characters.
    private CharacterLoader charaLoader;     // Contains all of the Characters.

    void Awake()
    {
        // Grab choices + choices text to be able to control.
        choices = new GameObject[3];
        choicesText = new GameObject[3];
        outcomes = new GameObject[3];

        for(int i = 0; i < 3; i++)
        {
            choices[i] = GameObject.Find("Choice " + i);
            choicesText[i] = GameObject.Find("Text " + i);
        }

        // Load Managers
        charaManager = GameObject.Find("Character Manager").GetComponent<CharacterManager>();

        // Dialogue Trigger load itself into ChoiceMakers
        for(int i = 0; i < 3; i++)
        {
            GameObject.Find("Choice " + i).GetComponent<ChoiceMaker>().LoadDialogueTrigger();
        }
    }

    void Start()
    {
        StartConvo();       // Set initial choices for conversation.
    }

    // Display Correct number of choices, based on Dialogue content.
    public void StartConvo ()
    {
        dialogue = convo.GetComponent<DialogueContent>().dialogue;      // Get components of the conversation.

        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);    // Start conversation text.
        charaManager.SetSpeaker(dialogue.speaker);                      // Set who is currently speaking.
        
        // Set expressions.
        charaManager.SetExpression(dialogue.expression);

        // Clear choices.
        for (int i = 0; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        // Set Active available choices.
        for (int i = 0; i < dialogue.choices.Length; i++)
        {
            choices[i].gameObject.SetActive(true);
            choicesText[i].gameObject.GetComponent<Text>().text = dialogue.choices[i];
            if(!dialogue.sceneSwitch)
            {
                outcomes[i] = dialogue.outcomes[i];
            }
        }
    }

    // On selection, continue to next Conversation set.
    public void Choose(int choice)
    {
        // Does choices affect character afinity?
        if(dialogue.changeAffinity)
        {
            FindObjectOfType<GameManager>().UpdateAffinity(dialogue.charaAffin[choice]);
        }

        // Load next Conversation, and start.
        if(!dialogue.sceneSwitch)
        {
            convo = outcomes[choice];
            StartConvo();
        }

        // Load next Scene
        else if (dialogue.sceneSwitch)
        {
            // Activate Choices Buttons before swapping scenes for next scene to be able to grab.
            for(int i = 0; i < 3; i++)
            {
                choices[i].gameObject.SetActive(true);
            }

            charaLoader.PurgeCharacters();
            FindObjectOfType<GameManager>().LoadSceneSequence(dialogue.sceneIndex[choice]);
        }
    }
}
