using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceLoader : MonoBehaviour
{
    public GameObject[] choices;           // Choices Button GameObject from Scene.
    public Text[] choicesText;       // Choices text to be displayed on buttons.

    void Start()
    {
        // Clear choices.
        for (int i = 0; i < choices.Length; i++)
        {
            choices[i].SetActive(false);
        }
    }

    public void SetChoiceText(string[] choiceStrings)
    {
        // Set Active available choices.
        for (int i = 0; i < choiceStrings.Length; i++)
        {
            choices[i].SetActive(true);
            choicesText[i].text = choiceStrings[i];
        }
    }
}
