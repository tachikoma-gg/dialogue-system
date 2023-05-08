using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject convoInit;            // First conversation of the Scene.
    private Dialogue dialogue;              // Class containing dialogue content. DialogueContent is used to pass this information from the template to Trigger.
    private GameObject currentConvo;        

    private CharacterManager charaManager;  // Class that loads in the characters.
    private CharacterLoader charaLoader;    // Contains all of the Characters.

    void Start()
    {
        StartConvo(convoInit);       // Set initial choices for conversation.
    }

    // Display Correct number of choices, based on Dialogue content.
    public void StartConvo (GameObject convo)
    {
        dialogue = convo.GetComponent<DialogueContent>().dialogue;      // Get components of the conversation.
        ChoiceController.executeChoice = null;

        LoaderModuleCheck(convo);
        
        FindObjectOfType<ChoiceLoader>().DisableChoices();
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        FindObjectOfType<CharacterManager>().SetSpeaker(dialogue.speaker);
        FindObjectOfType<ChoiceLoader>().SetChoiceText(dialogue.choices);
        FindObjectOfType<CharacterManager>().SetExpression(dialogue.expression);
    }

    // This is a temporary fix. Eventually, each module should be able to load themselves into the Choice Controller AND clear it before loading in.
    private void LoaderModuleCheck(GameObject convo)
    {
        ConversationLoader convoLoader = convo.GetComponent<ConversationLoader>();
        SceneLoader sceneLoader = convo.GetComponent<SceneLoader>();
        AffinityChanger affinityChanger = convo.GetComponent<AffinityChanger>();

        if(convoLoader != null)
        {
            ChoiceController.executeChoice += convoLoader.ChooseConversation;
        }
        if(sceneLoader != null)
        {
            ChoiceController.executeChoice += sceneLoader.ExecuteScene;
        }
        if(affinityChanger != null)
        {
            ChoiceController.executeChoice += affinityChanger.UpdateAffinity;
        }
    }
}
