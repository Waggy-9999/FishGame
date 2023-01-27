using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance; 

    public int numberOfCurrency;
    public TextMeshProUGUI currencyText;
    public enum CharacterTypes { Player1, Player2, Player3 };
    public List<GameObject> characters = new List<GameObject>();
    public GameObject currentCharacter;
    public CharacterTypes currentCharacterType;
    public Vector3 currentCharacterPosition;
    public GameObject VictoryPanel;

    void Awake()
    {
        instance = this;

        currentCharacterType = CharacterTypes.Player1;
        InstantiateCharacter((int)currentCharacterType);
    }

    public void InstantiateCharacter(int index)
    {
        if (index < 0 || index >= characters.Count || characters[index] == null)
            return;
        if (currentCharacter != null)
        {
            Destroy(currentCharacter);
        }
        Vector3 SpawnPosition = currentCharacter.transform.position;
        currentCharacter = Instantiate(characters[index], transform);
        currentCharacter.transform.position = SpawnPosition;
        currentCharacter.transform.localRotation = Quaternion.identity;
        currentCharacter.name = characters[index].name;
        currentCharacterType = (CharacterTypes)index;
        CharacterType();
    }

    public void SwapCharacter()
    {
        int nextCharacterType = (int)(currentCharacterType + 1) % characters.Count;
        InstantiateCharacter(nextCharacterType);
    }

    public void CharacterType()
    {
        switch (currentCharacterType)
        {
            case CharacterTypes.Player1:
                //print("Im player1");
                break;
            case CharacterTypes.Player2:
                //print("im player2");
                break;
            case CharacterTypes.Player3:
                //print("im player3");
                break;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void AddCurrency()
    {
        numberOfCurrency++;
        Debug.Log(numberOfCurrency);
        if (currencyText != null)
            currencyText.text = numberOfCurrency.ToString();
        if (numberOfCurrency == 20)
        {
            VictoryPanel.SetActive(true);
        }
    }
}
