using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AffinityChanger : MonoBehaviour
{
    [SerializeField]    private string[] characterAffinity;

    public void UpdateAffinity(int index)
    {
        FindObjectOfType<GameManager>().UpdateAffinity(characterAffinity[index]);
    } 
}
