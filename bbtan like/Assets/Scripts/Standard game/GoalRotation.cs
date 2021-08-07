
using UnityEngine;

public class GoalRotation : MonoBehaviour {

    public bool rotation = false;
    //public bool imageActive = true;
    //public bool activateGoal = false;
    private float angle = 0;
    //public GameObject image;

    void Update () {

        /*if(imageActive && activateGoal)
        {
            imageActive = false;
            image.SetActive(false);
        }
        */

        if (rotation)
        {
            angle += Time.deltaTime * 3;
            this.transform.eulerAngles = new Vector3(0, 0, 45 * Mathf.Sin(angle));
        }
	}
}
