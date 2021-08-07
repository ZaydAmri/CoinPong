using UnityEngine;

public class CameraScript : MonoBehaviour {

    public Camera camera;
    public float DesignAspectHeight;
    public float DesignAspectWidth;

    
    public void Start()
    {
        camera.aspect = 9f / 16f;
    }


    

}
