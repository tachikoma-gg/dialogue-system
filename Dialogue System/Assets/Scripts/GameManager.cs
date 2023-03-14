using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                // Debug.LogError("GameManager is NULL");
            }

            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }

        DontDestroyOnLoad(this);

        if(nextScene == 0)
        {
            LoadScene(1);
        }
        else
        {
            LoadScene(nextScene);
        }
    }
    #endregion

    public string[] character;  // All characters that the player directly interacts with in the game.
    public int[] affinity;      // What is the player's current affinity to that character.
    public int nextScene; 
    private int currentScene;
    public ChoiceMaker[] choiceButtons;

    // Update the player's affinity to a character.
    // Currently each choice can only affect the affinity of one character. However a choice should be able to affect multiple.
    // Need to convert strings, parse out information, and assign to correct methods. Develop and document syntax??
    public void UpdateAffinity(string chara, int affinityDelta)
    {
        for (int i = 0; i < character.Length; i++)
        {
            if(chara == character[i])
            {
                affinity[i] += affinityDelta;
            }
        }
    }

    public void LoadSceneSequence(int sceneIndex)
    {
        UnloadScene();
        LoadScene(sceneIndex);
    }

    public void UnloadScene()
    {
        Debug.Log("Unload Scene " + currentScene);
        SceneManager.UnloadSceneAsync(currentScene);
    }

    public void LoadScene(int sceneIndex)
    {
        Debug.Log("Load Scene " + sceneIndex);
        nextScene = sceneIndex;
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Additive);

        currentScene = nextScene;
    }
}
