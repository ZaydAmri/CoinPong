using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidGameUI : MonoBehaviour {

    public GameObject panelPause, gameOverPanel;
    public TABallController ball;
    public GameObject imageSound;
    //public BallController ball;
    void Start()
    {
        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            PlayerPrefs.SetInt("Sound", 0);
            ball.SetVolume(0);
            imageSound.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetInt("Sound", 1);
            ball.SetVolume(1);
            imageSound.SetActive(false);
        }
    }
    public void BoutonPause()
    {
        panelPause.SetActive(true);
        Time.timeScale = 0;
        ball.play = false;

    }

    public void BoutonReturn()
    {
        panelPause.SetActive(false);
        Time.timeScale = 1;
        ball.play = true;
    }
    public void BoutonSound()
    {
        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            PlayerPrefs.SetInt("Sound", 1);
            ball.SetVolume(1);
            imageSound.SetActive(false);
        }
        else
        {
            PlayerPrefs.SetInt("Sound", 0);
            ball.SetVolume(0);
            imageSound.SetActive(true);
        }
    }
    public void BoutonRestart()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
    public void BoutonHome()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    public void GameOverMenu()
    {
        Time.timeScale = 0;
        ball.play = false;
        
        gameOverPanel.SetActive(true);
    }

}
