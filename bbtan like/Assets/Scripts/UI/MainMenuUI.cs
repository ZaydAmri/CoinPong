
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour {

    public GameObject settingsPanel,customisePanel;
    public Text sound, google, facebook;
    public Transform StandardGameButton, AvoidGameButton, TargetGameButton;

    public float time = 0;
   
    private float angle = 0;
    Vector3 rotation1;
    void Start()
    {
        Time.timeScale = 1;
        if (!PlayerPrefs.HasKey("Sound"))
        {
            PlayerPrefs.SetInt("Sound", 1);
        }

        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            PlayerPrefs.SetInt("Sound", 0);

            sound.text = "Sound : OFF";
        }
        else
        {
            PlayerPrefs.SetInt("Sound", 1);
            sound.text = "Sound : ON";
        }
    }

    void Update()
    {
        time += Time.deltaTime*100;
        angle += Time.deltaTime * 5;
        rotation1 = new Vector3(0, 0, time);

        StandardGameButton.eulerAngles = rotation1;
        AvoidGameButton.eulerAngles = new Vector3(0, 0, 5 *  Mathf.Sin(angle));
        TargetGameButton.eulerAngles = new Vector3(0, 0, 2* angle);



    }



    public void LoadMainGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainGame");
    }
    public void LoadGammarjiGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Avoid");
    }
    public void LoadCollectCoinsGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Collect Game");
    }

    public void BoutonSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void BoutonReturnFromSettings()
    {
        settingsPanel.SetActive(false);
    }
    public void BoutonCustomise()
    {
        customisePanel.SetActive(true);
    }

    public void BoutonReturnFromCustomise()
    {
        customisePanel.SetActive(false);
    }

    public void BoutonRanking()
    {
        //pausePanel.SetActive(true);
    }

    public void BoutonAchievement()
    {
        //pausePanel.SetActive(true);
    }

    public void BoutonAddDannous()
    {
        //pausePanel.SetActive(true);
    }

    public void BoutonSound()
    {
        if(sound.text== "Sound : ON")
        {
            PlayerPrefs.SetInt("Sound", 0);
            sound.text = "Sound : OFF";
        }
        else
        {
            PlayerPrefs.SetInt("Sound", 1);
            sound.text = "Sound : ON";
        }
    }
    public void BoutonGoogle()
    {
        if (google.text == "Disconnected")
        {
            google.text = "Connected";
        }
        else
        {
            google.text = "Disconnected";
        }
    }
    public void BoutonFacebook()
    {
        if (facebook.text == "Disconnected")
        {
            facebook.text = "Connected";
        }
        else
        {
            facebook.text = "Disconnected";
        }
    }
    public void BoutonAboutUs()
    {
        //pausePanel.SetActive(true);
    }

    public void BoutonCustomiseCoins()
    {
        //pausePanel.SetActive(true);
    }

    public void BoutonCustomiseTrail()
    {
        //pausePanel.SetActive(true);
    }


    public void BoutonCustomiseTarget()
    {
        //pausePanel.SetActive(true);
    }

    //---------------------------------
}
