using UnityEngine;

public class GoalSpawner : MonoBehaviour {

    public GameObject goal1;
    public GameObject goal2;
    public GameObject goal3;

    

    // Use this for initialization
    void Start () {
        SpawnGoal(new Vector2(0,0),1);

    }
	
    
    public void SpawnGoal(Vector2 ballPosition, int level)
    {


        if (this.transform.childCount <2)
        {
            Vector2 pos = Vector2.zero;
            float distance = 0;





            


            if (level == 1)
            {
                while (distance < 2)
                {
                    pos = new Vector2(Random.Range(-1.79f, 1.8f), Random.Range(-3.97f, 2.43f));
                    distance = Vector2.Distance(ballPosition, pos);
                }
                float theta = Random.Range(0, 358);

                var goalTemp = Instantiate(goal1, new Vector3(pos.x, pos.y, 0), Quaternion.Euler(0f, 0f, theta));
                goalTemp.transform.SetParent(this.transform);
                
            }
            else if (level == 2)
            {

                while (distance < 2)
                {
                    pos = new Vector2(Random.Range(-1.79f, 1.8f), Random.Range(-3.97f, 2.43f));
                    distance = Vector2.Distance(ballPosition, pos);
                }
                float theta = Random.Range(0, 358);

                var goalTemp = Instantiate(goal1, new Vector3(pos.x, pos.y, 0), Quaternion.Euler(0f, 0f, theta));
                goalTemp.transform.SetParent(this.transform);
                goalTemp.GetComponent<GoalRotation>().rotation = true;
            }
            else if (level == 3)
            {
                while (distance < 2)
                {
                    pos = new Vector2(Random.Range(-1.67f, 1.69f), Random.Range(-3.79f, 2.29f));
                    distance = Vector2.Distance(ballPosition, pos);
                }
                float theta = Random.Range(0, 358);

                var goalTemp = Instantiate(goal2, new Vector3(pos.x, pos.y, 0), Quaternion.Euler(0f, 0f, theta));
                goalTemp.transform.SetParent(this.transform);
            }
            else if (level == 4)
            {
                while (distance < 2)
                {
                    pos = new Vector2(Random.Range(-1.67f, 1.69f), Random.Range(-3.79f, 2.29f));
                    distance = Vector2.Distance(ballPosition, pos);
                }
                float theta = Random.Range(0, 358);

                var goalTemp = Instantiate(goal2, new Vector3(pos.x, pos.y, 0), Quaternion.Euler(0f, 0f, theta));
                goalTemp.transform.SetParent(this.transform);
                goalTemp.GetComponent<GoalRotation>().rotation = true;
            }
            else if(level == 5)
            {
                while (distance < 2)
                {
                    pos = new Vector2(Random.Range(-1.6f, 2.0f), Random.Range(-4.0f, 3.5f));
                    distance = Vector2.Distance(ballPosition, pos);
                }
                float theta = Random.Range(0, 358);

                var goalTemp = Instantiate(goal3, new Vector3(pos.x, pos.y, 0), Quaternion.Euler(0f, 0f, theta));
                goalTemp.transform.SetParent(this.transform);
            }
            else
            {
                while (distance < 2)
                {
                    pos = new Vector2(Random.Range(-1.3f, 1.33f), Random.Range(-3.49f, 1.95f));
                    distance = Vector2.Distance(ballPosition, pos);
                }
                float theta = Random.Range(0, 358);

                var goalTemp = Instantiate(goal3, new Vector3(pos.x, pos.y, 0), Quaternion.Euler(0f, 0f, theta));
                goalTemp.transform.SetParent(this.transform);
                goalTemp.GetComponent<GoalRotation>().rotation = true;
            }
            
            
        }
         
    }
    
//--------------------------------------
}
