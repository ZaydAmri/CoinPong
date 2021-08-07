using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioManager : MonoBehaviour {

    public AudioClip touchBorder, touchGoal, gameOver, numberDown;
    private AudioSource audioSource;
    // Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();

    }
	
	public void PlayTouchBorder()
    {
        audioSource.PlayOneShot(touchBorder);
    }

    public void PlayTouchGoal()
    {
        audioSource.PlayOneShot(touchGoal);
    }

    public void PlayGameOver()
    {
        audioSource.PlayOneShot(gameOver);
    }

    public void PlayNumberDown()
    {
        audioSource.PlayOneShot(numberDown);
    }

}
