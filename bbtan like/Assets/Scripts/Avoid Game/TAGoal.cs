using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TAGoal : MonoBehaviour {

    public int level = 1;
    public GameObject green;
    public Vector2 scaleVector;
    public float limitScale;
    public float timeScale;
    
	// Update is called once per frame
	void Update () {

        if (scaleVector.x < 3)
        {
            Destroy(this.gameObject);
        }


        scaleVector.x -= Time.deltaTime/ timeScale;
        scaleVector.y -= Time.deltaTime/ timeScale;

        green.transform.localScale = new Vector3(scaleVector.x, scaleVector.y, 1);

    }




}
