using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;               // Object that displays the name of current speaker.
    public Text dialogueText;           // Object that displays the dialogue text.

    public Animator animator;           // Aniamtes in the Text box.
    
    private Queue<string> sentences;    // Sentence groups in the conversation.

    public GameObject choices;          // Buttons to make choice. Only displays after last sentence group.
    public GameObject next;             // Button to proceed in conversation.

    void Start()
    {
        sentences = new Queue<string>();
    }

    // Load Conversation Set, display first sentence.
    public void StartDialogue (Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);       // Display dialogue box.

        choices.gameObject.SetActive(false);    // Hide choices buttons.
        next.gameObject.SetActive(true);        // Show next button.

        nameText.text = dialogue.speaker;          // Set speaker name.

        sentences.Clear();                      // Clear sentences queue before loading in sentences.

        // Load in new sentence queue;
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();                  // Display sentence.
    }

    // Display next sentence + All other outcomes following sentence appearing.
    public void DisplayNextSentence()
    {
        string sentence = sentences.Dequeue();  // Take current sentence out of queue.
        StopAllCoroutines();                    // Cancel any other sentence typing. Important in case Next is spammed.
        StartCoroutine(TypeSentence(sentence)); // Type out current sentence.

        // If there are no more sentences in the queue, allow the player to make choices.
        if (sentences.Count == 0)
        {
            ShowChoices();
            return;
        }
    }

    // Animate the letters appearing.
    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    // Hide next, show Choices.
    void ShowChoices()
    {
        choices.gameObject.SetActive(true);
        next.gameObject.SetActive(false);
    }
}
