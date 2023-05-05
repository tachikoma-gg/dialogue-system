using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceMaker : MonoBehaviour
{
    public bool nextConvo;
    public bool nextScene;

    public void MakeChoice(int choice)
    {
        if(nextConvo)
        {
            FindObjectOfType<ConversationLoader>().ChooseConversation(choice);
            nextConvo = false;
        }
        
        if(nextScene)
        {
            FindObjectOfType<SceneLoader>().ExecuteScene(choice);
            nextScene = false;
        }
        
    }

    public void NextConvo()
    {
        nextConvo = true;
    }

    public void NextScene()
    {
        nextScene = true;
    }
}
