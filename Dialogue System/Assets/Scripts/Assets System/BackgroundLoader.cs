using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoader : MonoBehaviour
{
    public Sprite currentLocation;

    void Awake()
    {
        // On Scene load, find the Background Manager, and Load Background.
        FindObjectOfType<BackgroundManager>().LoadBackground(currentLocation);
    }
}
