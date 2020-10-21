using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    //SCORE
    public int coinPicked = 0;  //Nº of coins collected
    public int coinScore = 0; //Total Score of the coins
    //UI
    public GameObject gameOverUI;
    public GameObject scoreUI;
    public GameObject victoryUI;
    public GameObject PauseMenuUI;    
    public Text[] CoinScoreText;
    public Text FinalTime;
    

    //VARIABLES
    public bool gameIsPaused = false;
    private int g_NumberOfCoins;
    private AudioManager g_audiomanager;
    private bool g_canPause;

    

    /*///////////////UNITY FUCTIONS/////////////////*/
    private void Awake() 
    {
        g_NumberOfCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
        g_audiomanager = gameObject.GetComponent<AudioManager>();
    }
    private void Start() 
    {
        if(gm == null)
        {
            gm = gameObject.GetComponent<GameManager>();
        }
        g_audiomanager.Play("AmbientSound");
        foreach (Text ScoreText in CoinScoreText)
        {
            ScoreText.text = "Coins: 0/"+g_NumberOfCoins.ToString()+"\n"+"Score: 0";
        }
        g_canPause = true;
    }
    private void Update()
    {

    }
    /*///////////////VOID FUNCTIONS/////////////////*/  
    /*///SCORE///*/
    public void CoinCollected(int newCoinScore)
    {
        coinPicked++;  
        coinScore = newCoinScore+coinScore;

        ChangeScoreText(coinScore);
        if(coinPicked == g_NumberOfCoins)
        {
            Victory();
        }
    }    
    public void ChangeFinalTimeText()
    {
        FinalTime.text ="Time: "+Timer.timestring.ToString();
    }
    public void ChangeScoreText(int NewScore)//canvas
    {
        foreach (Text ScoreText in CoinScoreText)
        {
            ScoreText.text = "Coins: "+coinPicked.ToString()+"/"+g_NumberOfCoins.ToString()+"\n"+"Score: "+NewScore.ToString();
        }   
    }
    /*///VICTORY-GAMEOVER PANELS///*/
    public void GameOver() //canvas
    {
        g_audiomanager.Stop("AmbientSound");
        g_audiomanager.Play("DeathSound");
        gameOverUI.SetActive(true);
        scoreUI.SetActive(false);
        g_canPause = false;
        Time.timeScale = 0;
    }
    public void Victory()//canvas
    {
        g_audiomanager.Stop("AmbientSound");
        g_audiomanager.Play("WinSound");
        victoryUI.SetActive(true);
        scoreUI.SetActive(false);
        Time.timeScale = 0;
        g_canPause = false;
        ChangeFinalTimeText();
    }  

    /*///////////////PAUSECONTROLLERS//////////////////*/
    public void GamePause()
    {
        if(g_canPause)
        {
            gameIsPaused = !gameIsPaused;
            if(gameIsPaused)
            {
                g_audiomanager.Stop("AmbientSound");
                PauseMenuUI.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {            
                g_audiomanager.Play("AmbientSound");
                PauseMenuUI.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
