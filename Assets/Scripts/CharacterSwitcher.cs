using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{
    PlayerControls playerControls;


    public enum Characters {
        Character1,
        Character2,
        Character3
    }

    public Characters currentCharacter;

    private void Start()
    {
        playerControls = GetComponent<PlayerControls>();
    }

    void Update()
    {
        switch (currentCharacter)
        {
            case Characters.Character1:
                // code to control Character1
                playerControls.movePlayer();
                break;
            case Characters.Character2:
                // code to control Character2
                break;
            case Characters.Character3:
                // code to control Character3
                break;
        }
    }
}
