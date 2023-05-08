using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortraitLoader : MonoBehaviour
{
    [SerializeField]    private GameObject[] expressions;    // All available portraits for this character.

    public void LoadExpression(string express)
    {
        for(int i = 0; i < expressions.Length; i++)
        {
            // Disable all expressions.
            expressions[i].gameObject.SetActive(false);

            // Set active expression specified in dialogue content class.
            // Expressions are set in order of list. Make sure the order matches the character order.
            if(expressions[i].gameObject.name == express)
            {
                expressions[i].gameObject.SetActive(true);
            }
        }
    }
}
