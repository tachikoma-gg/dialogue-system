using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private Text nameText, dialogueText;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject choices, next;

    private Queue<string> sentences;

    private void Awake()
    {
        DialogueTrigger.startConversation += StartDialogue;
    }

    private void Start()
    {
        sentences = new Queue<string>();
    }

    // Load Conversation Set, display first sentence.
    public void StartDialogue (Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);       // Display dialogue box. OBSOLETE.
        choices.gameObject.SetActive(false);    // Hide choices buttons. MOVE TO START CONVO DELEGATE
        next.gameObject.SetActive(true);        // Show next button. MOVE TO START CONVO DELEGATE
        nameText.text = dialogue.speaker;       // Set speaker name.
        sentences.Clear();

        // Load in new sentence queue;
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
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
            ShowChoices(); // trigger end of convo delegate here.
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

    // Hide next, show Choices. SUBSCRIBE TO END CONVO DELEGATE
    void ShowChoices()
    {
        choices.gameObject.SetActive(true);
        next.gameObject.SetActive(false);
    }
}
