using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int score = 0;

    private void Awake()
    {
        setUpSingleton();
    }

    private void setUpSingleton()
    {
        int numberOfGameManagers = FindObjectsOfType<GameManager>().Length;
        if(numberOfGameManagers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    
    public void ResetScore(){
        score = 0;
    }
    public int getScore()
    {
        return score;
    }

    public void addToScore(int scoreValue)
    {
        score += scoreValue;
    }

    public void restartGame()
    {
        Destroy(gameObject);
    }
   
}
