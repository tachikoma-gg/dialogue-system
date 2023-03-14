using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    void Awake()
    {
        GameObject.Find("Dialogue Screen").GetComponent<Animator>().SetBool("IsOpen", false);
    }

    public void Restart()
    {
        FindObjectOfType<GameManager>().LoadSceneSequence(1);
    }
}
