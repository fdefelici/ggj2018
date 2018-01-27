using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "new Lifes", menuName = "PlayersLifes")]
public class PleyerLives : ScriptableObject
{
    public Image[] LifesPlayerOne;
    public int PlayerOneLifes;
    public GameObject[] LifesPlayerTwo;
    public int PlayerTwoLifes;
}
