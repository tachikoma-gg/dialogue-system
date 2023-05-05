using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SceneLoader : MonoBehaviour
{
    private DialogueTrigger dialogueTrigger;
    public int[] sceneIndex;

    public delegate void LoadScene(int scene);
    LoadScene loadScene;

    void Awake()
    {
        dialogueTrigger = FindObjectOfType<DialogueTrigger>();      // Set Dialogue Trigger;
    }

    void Start()
    {
        loadScene = ExcecuteScene;
    }

    public void ExcecuteScene(int scene)
    {
        // Clear characters in current scene to make room for characters in next scene.
        CharacterLoader charaLoader = FindObjectOfType<CharacterLoader>().GetComponent<CharacterLoader>();
        charaLoader.PurgeCharacters();  // Move this to Character Loader.

        // Load scene from Game Manager.
        FindObjectOfType<GameManager>().LoadSceneSequence(scene);
    }
}
