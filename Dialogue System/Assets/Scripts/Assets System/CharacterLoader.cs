using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLoader : MonoBehaviour
{
    public GameObject[] character;              // Characters that will be in the scene.
    private CharacterManager charaManager;      // Controls character positions and animation.
    private GameObject[] charaActive;           // Characters active in the scene.

    void Awake()
    {
        charaManager = FindObjectOfType<CharacterManager>();

        // Set Array Size for number of characters active in scene.
        charaActive = new GameObject[character.Length];
        charaManager.charaAnim = new Animator[character.Length];
        charaManager.charaPort = new PortraitLoader[character.Length];
        charaManager.charaActive = new GameObject[character.Length];

        // Load characters in scene.
        for(int i = 0; i < character.Length; i++)
        {
            charaActive[i] = Instantiate(character[i]);                                 // Instantiate character.
            charaActive[i].transform.parent = charaManager.charaAnchor[i].transform;    // Parent character to anchor.

            charaManager.charaAnim[i] = charaActive[i].GetComponent<Animator>();        // Get animator for speaker status.
            charaManager.charaPort[i] = charaActive[i].GetComponent<PortraitLoader>();  // Get portrait loader class for each character.
            charaManager.charaActive[i] = charaActive[i];                                 // Pass active characters to Character Manager.
        }
    }

    // Destroy all characters before loading next scene.
    public void PurgeCharacters()
    {
        for(int i = 0; i < charaActive.Length; i++)
        {
            Destroy(charaActive[i].gameObject);
        }
    }
}
