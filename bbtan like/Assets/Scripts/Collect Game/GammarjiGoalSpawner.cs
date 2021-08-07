
using UnityEngine;

public class GammarjiGoalSpawner : MonoBehaviour
{
    public GameObject goal1;
    //public GammarjiBallController ballController;
    GameObject tempGoal;

    void Start()
    {
        SpawnGoal(new Vector2(0, 0));

    }


    public void SpawnGoal(Vector2 ballPosition)
    {


        if (this.transform.childCount < 2)
        {
            Vector2 pos = Vector2.zero;
            float distance = 0;

            while (distance < 2)
            {
                pos = new Vector2(Random.Range(-1.66f, 1.65f), Random.Range(-3.85f, 2.58f));
                distance = Vector2.Distance(ballPosition, pos);
            }
            
            var goalTemp = Instantiate(goal1, new Vector3(pos.x, pos.y, 0), Quaternion.Euler(0f, 0f, 0f));
            goalTemp.transform.SetParent(this.transform);
            tempGoal = (GameObject)goalTemp.gameObject;


        }   

    }

    public void DeleteGoal()
    {
        Destroy(tempGoal.gameObject);
    }

   

    //-----------------------------
}