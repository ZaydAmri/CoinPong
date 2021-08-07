
using UnityEngine;

public class TAGoalSpawner : MonoBehaviour {

    public GameObject goalUp;
    public GameObject goalDown;
    public GameObject goal1;
    public GameObject goal2;
    public GameObject goal3;

    public float random = 0;
    public bool up = true;
    GameObject tempGoal;

    void Start()
    {
        SpawnGoal(1);

    }

    public void SpawnGoal( int level)
    {


        if (this.transform.childCount < 2)
        {

            /*
            Vector2 pos = Vector2.zero;
            float distance = 0;

            while (distance < 2)
            {
                pos = new Vector2(Random.Range(-1.6f, 2.0f), Random.Range(-4.0f, 3.5f));
                distance = Vector2.Distance(ballPosition, pos);
            }
            float theta = Random.Range(0, 358);
            */
            random = Random.Range(0, 2);
            if (random < 1)
            {
                up = true;
            }else
            {
                up = false;
            }
            if (level == 1)
            {
                if (up)
                {
                    goalUp.gameObject.SetActive(false);
                    goalDown.gameObject.SetActive(true);
                    var goalTemp = Instantiate(goal1, new Vector3(Random.Range(-1.83f, 1.83f), 3.38f, 0), Quaternion.Euler(0f, 0f, 0f));
                    goalTemp.transform.SetParent(this.transform);
                    //up = false;
                    tempGoal = (GameObject)goalTemp.gameObject;
                }
                else
                {
                    goalUp.gameObject.SetActive(true);
                    goalDown.gameObject.SetActive(false);
                    var goalTemp = Instantiate(goal1, new Vector3(Random.Range(-1.83f, 1.83f), -4.87f, 0), Quaternion.Euler(0f, 0f, 0f));
                    goalTemp.transform.SetParent(this.transform);
                    //up = true;
                    tempGoal = (GameObject)goalTemp.gameObject;
                }
               
            }
            else if (level == 2)
            {
                if (up)
                {
                    goalUp.gameObject.SetActive(false);
                    goalDown.gameObject.SetActive(true);
                    var goalTemp = Instantiate(goal2, new Vector3(Random.Range(-1.76f, 2.28f), 3.38f, 0), Quaternion.Euler(0f, 0f, 0f));
                    goalTemp.transform.SetParent(this.transform);
                    //up = false;
                    tempGoal = (GameObject)goalTemp.gameObject;
                }
                else
                {
                    goalUp.gameObject.SetActive(true);
                    goalDown.gameObject.SetActive(false);
                    var goalTemp = Instantiate(goal2, new Vector3(Random.Range(-1.76f, 2.28f), -4.87f, 0), Quaternion.Euler(0f, 0f, 0f));
                    goalTemp.transform.SetParent(this.transform);
                    //up = true;
                    tempGoal = (GameObject)goalTemp.gameObject;
                }
            }
            else
            {
                if (up)
                {
                    goalUp.gameObject.SetActive(false);
                    goalDown.gameObject.SetActive(true);
                    var goalTemp = Instantiate(goal3, new Vector3(Random.Range(-1.76f, 2.79f), 3.38f, 0), Quaternion.Euler(0f, 0f, 0f));
                    goalTemp.transform.SetParent(this.transform);
                    //up = false;
                    tempGoal = (GameObject)goalTemp.gameObject;
                }
                else
                {
                    goalUp.gameObject.SetActive(true);
                    goalDown.gameObject.SetActive(false);
                    var goalTemp = Instantiate(goal3, new Vector3(Random.Range(-1.76f, 2.79f), -4.87f, 0), Quaternion.Euler(0f, 0f, 0f));
                    goalTemp.transform.SetParent(this.transform);
                    //up = true;
                    tempGoal = (GameObject)goalTemp.gameObject;
                }
            }
            

        }

    }


    public void DeleteGoal()
    {
        Destroy(tempGoal.gameObject);
    }
}
