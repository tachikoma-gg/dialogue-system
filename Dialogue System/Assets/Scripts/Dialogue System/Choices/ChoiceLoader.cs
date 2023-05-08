using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceLoader : MonoBehaviour
{
    [SerializeField]    private GameObject[] choices;           // Choices Button GameObject from Scene.
    [SerializeField]    private Text[] choicesText;       // Choices text to be displayed on buttons.

    public void DisableChoices()
    {
        // Disable choices.
        for (int i = 0; i < choices.Length; i++)
        {
            choices[i].SetActive(false);
        }
    }

    public void EnableChoies()
    {
        // Enable choices.
        for (int i = 0; i < choices.Length; i++)
        {
            choices[i].SetActive(true);
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
