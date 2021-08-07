
using UnityEngine;

public class GameManager : MonoBehaviour {

    

    void Awake()
    {
        if (!PlayerPrefs.HasKey("Standard_highscore"))
        {
            PlayerPrefs.SetInt("Standard_highscore", 0);
        }

        if (!PlayerPrefs.HasKey("Standard_highcombo"))
        {
            PlayerPrefs.SetInt("Standard_highcombo", 0);
        }
    }

    


    public void SetHighscore(int x)
    {
        PlayerPrefs.SetInt("Standard_highscore", x);
    }

    public int GetHighscore()
    {
        int x = PlayerPrefs.GetInt("Standard_highscore");
        return x;
    }

    public void SetHighCombo(int x)
    {
        PlayerPrefs.SetInt("Standard_highcombo", x);
    }

    public int GetHighCombo()
    {
        int x = PlayerPrefs.GetInt("Standard_highcombo");
        return x;
    }


}
