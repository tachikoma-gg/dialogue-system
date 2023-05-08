using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceMaker : MonoBehaviour
{
    public void MakeChoice(int choice)
    {
        ChoiceController.executeChoice?.Invoke(choice);
    }
}
