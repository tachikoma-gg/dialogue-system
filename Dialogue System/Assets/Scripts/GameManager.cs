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

    public string[] character;      // All characters that the player directly interacts with in the game.
    public int[] affinity;          // What is the player's current affinity to that character.
    private string[] affinityRaw; // Name and Affinity delta received from Choices.
    public int nextScene; 
    private int currentScene;
    private ChoiceMaker[] choiceButtons;

    // Update the player's affinity to a character.
    // Currently each choice can only affect the affinity of one character. However a choice should be able to affect multiple.
    // Need to convert strings, parse out information, and assign to correct methods. Develop and document syntax??
    // Should we be using Dictionaries? I need to learn that first.


    public void UpdateAffinity(string charaAffin) // Don't forget to change string to string[] in Dialogue.cs
    {
        // Debug.Log(charaAffin + " received by Game Manager. UpdateAffinity() triggered.");

        string[] affinityRaw = charaAffin.Split(char.Parse("_"));     // Splits all input into array. Can contain multiple charactes/affinities.

        // Debug.Log(affinityRaw.Length + " items in affinityRaw.");

        for(int j = 0; j < affinityRaw.Length; j++)
        {
            for(int k = 0; k < character.Length; k++)
            {
                if(affinityRaw[j] == character[k])
                {
                    // Debug.Log("Change " + affinityRaw[j] + "'s affinity by " + affinityRaw[j+1]);
                    j += 1;
                    affinity[k] += int.Parse(affinityRaw[j]);
                    // Debug.Log(character[k] + "'s affinity is now " + affinity[k]);
                }
            }
        }
    }
    
    /*
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
    */

    // Return the player's affinity to a character.
    public int GetAffinity(string chara)
    {
        for (int i = 0; i < character.Length; i++)
        {
            if(chara == character[i])
            {
                return affinity[i];
            }
        }

        // If you see this value, you messed up.
        return 9000;
    }

    public void LoadSceneSequence(int sceneIndex)
    {
        UnloadScene();
        LoadScene(sceneIndex);
    }

    public void UnloadScene()
    {
        SceneManager.UnloadSceneAsync(currentScene);
    }

    public void LoadScene(int sceneIndex)
    {
        nextScene = sceneIndex;
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Additive);

        currentScene = nextScene;
    }
}
