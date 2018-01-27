using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    public GameObject[] ImagePlayerOne;
    public GameObject[] ImagePlayerTwo;
    public int PlayerOneLifes;
    public int PlayerTwoLifes;
    public static int playerOneLifes;
    public static int playerTwoLifes;
    // Use this for initialization
    void Start ()
    {
        playerOneLifes = PlayerOneLifes;
        playerTwoLifes = PlayerTwoLifes;
    }
	
	// Update is called once per frame
	void Update ()
    {
        TurnOffLife(ImagePlayerOne, playerOneLifes, PlayerOneLifes);
        TurnOffLife(ImagePlayerTwo, playerTwoLifes, PlayerTwoLifes);
    }
    
   void TurnOffLife(GameObject[] imagePlayer, int playerLifes, int Playerlifes)
    {
        if(playerLifes != PlayerOneLifes)
        {
            imagePlayer[playerLifes].SetActive(false);
            Playerlifes = playerLifes;
        }
    }

    public static int GetPlayerOneLifes()
    {
        return playerOneLifes;
    }
    public static int GetPlayerTwoLifes()
    {
        return playerTwoLifes;
    }
}
