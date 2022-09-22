using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 2f;
    public Animator transition;
    public Image fade;
    public bool inputFade, exitFade;


void Start()
{   
    if(SceneManager.GetActiveScene().name == "Level 1" || SceneManager.GetActiveScene().name == "Level 2" ||  SceneManager.GetActiveScene().name == "Level 3")
    {
        PlayerPrefs.SetInt("CurrentScore", 0);
    }
    fade.enabled = inputFade;
        
}


public void StartButton() //to continue where i left of
{
    string currLevel = PlayerPrefs.GetString("CurrentLevel");
    if(currLevel == null || currLevel == "")
    {
       StartCoroutine(WaitAndLoad("Level 1"));
    }
    else
    {
        StartCoroutine(WaitAndLoad(currLevel));
    }
}



    
public void loadLevel(string levelName)
  {
      
      if(levelName == "Level 1" || levelName == "Level 2" || levelName == "Level 3")
      {
    
          if(FindObjectOfType<GameManager>())
            FindObjectOfType<GameManager>().ResetScore();
          PlayerPrefs.SetString("CurrentLevel", levelName);
          PlayerPrefs.SetInt("CurrentScore", 0);

      }



    if(levelName == "Level 1 Completed")
     {
        PlayerPrefs.SetString("CurrentLevel", "Level 2"); 
     }

    if(levelName == "Level 2 Completed")
     {
         PlayerPrefs.SetString("CurrentLevel", "Level 3"); 
     }




     if(levelName == null || levelName == "")
     {
        
     if(FindObjectOfType<GameManager>())
         FindObjectOfType<GameManager>().ResetScore();
         PlayerPrefs.SetInt("CurrentScore", 0);
         SceneManager.LoadScene(PlayerPrefs.GetString("CurrentLevel"));
         Debug.Log("1111111111");
      }
      else{
          
          SceneManager.LoadScene(levelName);
          Debug.Log("asdfasfdasfd");
        }

       
     }

  
  
   public IEnumerator WaitAndLoad(string levelName)
   {
       fade.enabled = exitFade;
       if(transition.enabled)
       {
        transition.SetTrigger("Start");
       }
         yield return new WaitForSeconds(delayInSeconds);
         loadLevel(levelName);
        
   }

    public IEnumerator DelayAnimation(string levelName, float waitTime)
   {

         yield return new WaitForSeconds(waitTime);
         StartCoroutine(WaitAndLoad(levelName)); 
        
   }
   

   public void StartWait(string levelName) //For Buttons
   {
       StartCoroutine(WaitAndLoad(levelName));
   }

   public void StartDelayAnimation(string levelName, float waitTime)
   {
        StartCoroutine(DelayAnimation(levelName, waitTime));
   }


   public void BossDied()
   {

       if(SceneManager.GetActiveScene().name == "Level 1")
        {
            StartCoroutine(DelayAnimation("Level 1 Completed", 2));
            int score = FindObjectOfType<GameManager>().getScore();
            PlayerPrefs.SetInt("CurrentScore", score);

            if(score > PlayerPrefs.GetInt("HighScore1"))
            {
                PlayerPrefs.SetInt("HighScore1", score);
            }
        }

       else if(SceneManager.GetActiveScene().name == "Level 2")
       {
          StartCoroutine(DelayAnimation("Level 2 Completed", 2));
          int score = FindObjectOfType<GameManager>().getScore();
          PlayerPrefs.SetInt("CurrentScore", score);

            if(score > PlayerPrefs.GetInt("HighScore2"))
            {
                PlayerPrefs.SetInt("HighScore2", score);
            }
       }
       else if(SceneManager.GetActiveScene().name == "Level 3")
       {
         StartCoroutine(DelayAnimation("Level 3 Completed", 2));
          int score = FindObjectOfType<GameManager>().getScore();
          PlayerPrefs.SetInt("CurrentScore", score);

            if(score > PlayerPrefs.GetInt("HighScore3"))
            {
                PlayerPrefs.SetInt("HighScore3", score);
            }
            
        }
   }

   public void UpdateHighScore(){
       int score = FindObjectOfType<GameManager>().getScore();
       if(SceneManager.GetActiveScene().name == "Level 1")
        {
            if(score > PlayerPrefs.GetInt("HighScore1"))
            {
                PlayerPrefs.SetInt("HighScore1", score);
            }
        }else if(SceneManager.GetActiveScene().name == "Level 2")
       {
           Debug.Log("asdfasfdasfd");
            if(score > PlayerPrefs.GetInt("HighScore2"))
            {
                PlayerPrefs.SetInt("HighScore2", score);
            }
       }else if(SceneManager.GetActiveScene().name == "Level 3")
       {
            if(score > PlayerPrefs.GetInt("HighScore3"))
            {
                PlayerPrefs.SetInt("HighScore3", score);
            }
       }
   }
   

   public void quitGame()
   {
       Application.Quit();
   }



}
