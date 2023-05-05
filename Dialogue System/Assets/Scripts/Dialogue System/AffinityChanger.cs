using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AffinityChanger : MonoBehaviour
{
    public string[] characterAffinity;

    public void UpdateAffinity()
    {
        int index = 0;
        FindObjectOfType<GameManager>().UpdateAffinity(characterAffinity[index]);
    } 
}
