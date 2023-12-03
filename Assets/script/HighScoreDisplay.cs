using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreDisplay : MonoBehaviour
{
    [SerializeField]
    private TMP_Text highscoreText;

    void Start()
    {
        if (highscoreText != null)
        {
            int highscore = PlayerPrefs.GetInt("Highscore", 0);
            highscoreText.text = "Highscore: " + highscore.ToString();
        }
    }
}