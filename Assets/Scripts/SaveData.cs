using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class SaveData : MonoBehaviour
{

    [SerializeField] Text HighScore1;
    [SerializeField] Text HighScore2; 
    [SerializeField] Text HighScore3;

    public SerializedData serializedData;
    
    string restoreHighscore;

    void Start()
    {
        serializedData = new SerializedData();
        HighScore1.text = PlayerPrefs.GetInt("HighScore1").ToString();
        HighScore2.text = PlayerPrefs.GetInt("HighScore2").ToString();
        HighScore3.text = PlayerPrefs.GetInt("HighScore3").ToString();
       
    }


}



