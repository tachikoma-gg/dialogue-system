using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SceneLoader : MonoBehaviour
{
    private DialogueTrigger dialogueTrigger;
    public int[] sceneIndex;

    void Awake()
    {
        dialogueTrigger = FindObjectOfType<DialogueTrigger>();      // Set Dialogue Trigger;
    }

    public void ExecuteScene(int scene)
    {
        // Clear characters in current scene to make room for characters in next scene.
        CharacterLoader charaLoader = FindObjectOfType<CharacterLoader>().GetComponent<CharacterLoader>();
        charaLoader.PurgeCharacters();  // Move this to Character Loader.


        // Load scene from Game Manager.
        FindObjectOfType<GameManager>().LoadSceneSequence(sceneIndex[scene]);
    }
}
