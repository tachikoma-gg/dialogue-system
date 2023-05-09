using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]    private int[] sceneIndex;

    private void Awake()
    {
        ChoiceController.executeChoice += ExecuteScene;
        DialogueTrigger.endConversation += ClearScene;
    }

    public void ExecuteScene(int scene)
    {
        FindObjectOfType<ChoiceLoader>().EnableChoies();

        // Clear characters in current scene to make room for characters in next scene.
        FindObjectOfType<CharacterLoader>().PurgeCharacters();

        // Load scene from Game Manager.
        FindObjectOfType<GameManager>().LoadSceneSequence(sceneIndex[scene]);
    }

    public void ClearScene()
    {
        ChoiceController.executeChoice -= ExecuteScene;
        DialogueTrigger.endConversation -= ClearScene;
    }
}
