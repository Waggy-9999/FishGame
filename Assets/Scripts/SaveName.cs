using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveName : MonoBehaviour
{
    public TMP_InputField playerNameInput;
    public TMP_Text playerNameText;

    // Start is called before the first frame update
    public void Start()
    {
        // Check if player name has been saved previously
        if (PlayerPrefs.HasKey("playerName"))
        {
            string playerName = PlayerPrefs.GetString("playerName");
            playerNameInput.text = playerName;
            playerNameText.text = playerName;
        }
    }

    // Method to save the player's name
    public void SavePlayerName()
    {
        string playerName = playerNameInput.text;
        Debug.Log("Player name: " + playerName);
        PlayerPrefs.SetString("playerName", playerName);
        playerNameText.text = playerName;
    }

}