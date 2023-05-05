using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Dialogue
{
    public string speaker;          // Who is currently speaking.
    public string[] expression;     // Expressions of each character.

    [TextArea(3,10)]
    public string[] sentences;      // All sentences in current conversation set before player makes a choice.

    public string[] choices;        // Text for choices to be displayed.
}
