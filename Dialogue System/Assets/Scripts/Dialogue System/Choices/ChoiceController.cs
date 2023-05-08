using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceController : MonoBehaviour
{
    public delegate void ExecuteChoice(int choice);
    public static ExecuteChoice executeChoice;
}
