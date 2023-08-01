using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera firstCamera;
    public Camera secondCamera;
    void Start()
    {
        secondCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C)) 
        {
            ToggleCameras();
        }
    }
    void ToggleCameras()
    {
        firstCamera.enabled = !firstCamera.enabled;
        secondCamera.enabled = !secondCamera.enabled;
    }
}
