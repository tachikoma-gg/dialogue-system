using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
The Background Manager is persistent in the game.
As different scenes load in, the Background Loader will access this class to load in the background.
*/

public class BackgroundManager : MonoBehaviour
{
    public SpriteRenderer background;

    // Triggered in Background Loader class.
    public void LoadBackground(Sprite currentLocation)
    {
        background.sprite = currentLocation;
    }
}
