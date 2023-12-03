using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoreManager : MonoBehaviour
{
    public void SaveHighscore(int highscore)
    {
        //save the highscore
        PlayerPrefs.SetInt("Highscore", highscore);
        PlayerPrefs.Save();
    }
}