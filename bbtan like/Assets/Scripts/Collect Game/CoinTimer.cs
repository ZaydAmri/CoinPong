using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTimer : MonoBehaviour {

    public float time = 0;
    public CollectBallManager ballManager;
    public GammarjiGoalSpawner goalSpawner;
    public Transform child;

    void Awake()
    {
        ballManager = GameObject.Find("ball").GetComponent<CollectBallManager>();
        goalSpawner = GameObject.Find("Goal Spawner").GetComponent<GammarjiGoalSpawner>();
    }

    void Update()
    {
        if (ballManager.begin)
        {
            time += Time.deltaTime;

            child.localScale = new Vector3(0.1f + 0.9f * (time / 2), 0.1f + 0.9f * (time / 2), 1);

            if (time > 2)
            {
                ballManager.TimerOff();

                Destroy(this.gameObject);

                ballManager.SpawnNew();
            }
        }

        


    }


}
