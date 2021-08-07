
using UnityEngine;

public class GammarjiManager : MonoBehaviour {

    void Awake()
    {
        if (!PlayerPrefs.HasKey("Collect_highscore"))
        {
            PlayerPrefs.SetInt("Collect_highscore", 0);
        }
        if (!PlayerPrefs.HasKey("Collect_highCombo"))
        {
            PlayerPrefs.SetInt("Collect_highCombo", 0);
        }
    }




    public void SetHighscore(int x)
    {
        PlayerPrefs.SetInt("Collect_highscore", x);
    }

    public int GetHighscore()
    {
        int x = PlayerPrefs.GetInt("Collect_highscore");
        return x;
    }

    public void SetHighCombo(int x)
    {
        PlayerPrefs.SetInt("Collect_highCombo", x);
    }

    public int GetHighCombo()
    {
        int x = PlayerPrefs.GetInt("Collect_highCombo");
        return x;
    }
}
