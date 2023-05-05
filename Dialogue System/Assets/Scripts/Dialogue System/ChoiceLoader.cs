using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceLoader : MonoBehaviour
{
    private GameObject[] choices;           // Choices Button GameObject from Scene.
    private GameObject[] choicesText;       // Choices text to be displayed on buttons.

    private DialogueTrigger dialogueTrigger;

    void Awake()
    {
        // Grab choices + choices text to be able to control.
        choices = new GameObject[3];
        choicesText = new GameObject[3];

        for(int i = 0; i < 3; i++)
        {
            choices[i] = GameObject.Find("Choice " + i);
            choicesText[i] = GameObject.Find("Text " + i);
        }
    }

    void Start()
    {
        // Clear choices.
        for (int i = 0; i < choices.Length; i++)
        {
            choices[i].SetActive(false);
        }

        // Set Active available choices.
        for (int i = 0; i < dialogueTrigger.Choices().Length; i++)
        {
            choices[i].SetActive(true);
            choicesText[i].GetComponent<Text>().text = dialogueTrigger.Choices()[i];
        }
    }
}
