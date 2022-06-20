using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fovScript : MonoBehaviour
{
    private float fov;
    public Camera thisCamera;
    // Start is called before the first frame update
    void Start()
    {
        fov = PlayerPrefs.GetFloat("fov", 70);
        thisCamera.fieldOfView = fov;
    }
    public void updateSettings() {
        fov = PlayerPrefs.GetFloat("fov", 70);
        thisCamera.fieldOfView = fov;
    }
}
