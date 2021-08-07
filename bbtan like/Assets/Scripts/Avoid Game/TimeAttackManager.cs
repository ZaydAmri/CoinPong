
using UnityEngine;

public class TimeAttackManager : MonoBehaviour {

    void Awake()
    {
        if (!PlayerPrefs.HasKey("Avoid_highscore"))
        {
            PlayerPrefs.SetInt("Avoid_highscore", 0);
        }
        if (!PlayerPrefs.HasKey("Avoid_highCombo"))
        {
            PlayerPrefs.SetInt("Avoid_highCombo", 0);
        }
    }

    


    public void SetHighscore(int x)
    {
        PlayerPrefs.SetInt("Avoid_highscore", x);
    }

    public int GetHighscore()
    {
        int x = PlayerPrefs.GetInt("Avoid_highscore");
        return x;
    }

    public void SetHighCombo(int x)
    {
        PlayerPrefs.SetInt("Avoid_highCombo", x);
    }

    public int GetHighCombo()
    {
        int x = PlayerPrefs.GetInt("Avoid_highCombo");
        return x;
    }
}
