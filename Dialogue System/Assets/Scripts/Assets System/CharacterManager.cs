using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public GameObject[] charaActive;        // Characters active in scene.
    public GameObject[] charaAnchor;        // Where characters appear.
    public PortraitLoader[] charaPort;      // Portrait Loader class for each character.
    
    public Animator[] charaAnim;            // Animators of characters active in the scene.
    private Animator charaSpeaking;         // Animator of character that is currently speaking.

    // private string[] charaExpress;          // Character name + Expression. Every other line.
    // private string[] expression;            // Expressions?
    // Should dictionaries be used instead? How to access data from dictionaries?

    private void Awake()
    {
        DialogueTrigger.startConversation += SetSpeaker;
        DialogueTrigger.startConversation += SetExpression;
    }

    public void SetSpeaker(Dialogue dialogue)
    {
        string charaName = dialogue.speaker;
        // Set private array size for expressions method.
        // charaExpress = new string[charaActive.Length];
        // expression = new string[charaActive.Length];

        // Unset all speakers.
        for(int i = 0; i < charaAnim.Length; i++)
        {
            charaAnim[i].SetBool("Speaking_b", false);
        }

        // Set current speaker.
        charaSpeaking = GameObject.Find(charaName + "(Clone)").GetComponent<Animator>();
        charaSpeaking.SetBool("Speaking_b", true);
    }

    // Set active expression for each character. Trigger this from Dialogue Trigger
    public void SetExpression(Dialogue dialogue)
    {
        string[] expression = dialogue.expression;

        // Parse out each string into Active Character and expression.
        for(int i = 0; i < charaActive.Length; i++)
        {
            
        }

        for(int i = 0; i < charaPort.Length; i++)
        {
            // Populate chracter name list.
            // Populate expressions list.

            // Compare character with character name list.
            // If match, set expression based in i.

            charaPort[i].LoadExpression(expression[i]);
        }
    }
}
