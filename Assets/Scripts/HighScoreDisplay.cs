using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI highScore, score;
    public string highScoreKey;
    void Start()
    {
        int actualHighScore = 0;
        string highScoreStr = PlayerPrefs.GetString("CurrentLevel");

        switch(highScoreStr){
            case "Level 1":
                actualHighScore = PlayerPrefs.GetInt("HighScore1");
            break;

            case "Level 2":
                actualHighScore = PlayerPrefs.GetInt("HighScore2");
            break;

            case "Level 3":
                actualHighScore = PlayerPrefs.GetInt("HighScore3");
            break;
        }
        Debug.Log("ASFIJASOFIJAFS " + PlayerPrefs.GetInt("CurrentScore"));
        highScore.text = "Highest Score: " + actualHighScore.ToString();
        score.text = "Score: " + PlayerPrefs.GetInt("CurrentScore").ToString();
    }

}
