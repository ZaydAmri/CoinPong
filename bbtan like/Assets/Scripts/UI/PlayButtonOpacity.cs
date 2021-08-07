using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonOpacity : MonoBehaviour {

    public float time=0;
    private bool reverse = false;
    private float angle = 0;
	
	// Update is called once per frame
	void Update () {

        angle += time;

        GetComponent<CanvasGroup>().alpha = Mathf.Abs(Mathf.Sin(angle));

        

	}
}
