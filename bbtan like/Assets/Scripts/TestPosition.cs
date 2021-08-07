using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPosition : MonoBehaviour {

    public bool validPosition = true;
    
    // Use this for initialization
    void awake()
    {
       
    }
    void Start () {
        

    }
	
	


    void OnCollisionEnter2D(Collision2D coll)
    {
        
        if (coll.gameObject.CompareTag("wall"))
        {
            Debug.Log("changed");
            validPosition = false;
            GoalSpawner gS = GameObject.Find("Goal Spawner").GetComponent<GoalSpawner>();
            Vector2 pos = GameObject.Find("ball").transform.position;
            int level = GameObject.Find("ball").GetComponent<BallController>().level;
            Destroy(this.gameObject);
            gS.SpawnGoal(pos, level);

        }
    }

}
