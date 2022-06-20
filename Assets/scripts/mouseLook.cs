using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{


    public Camera thisCamera;
    private float mouseSens;
    private float scopedMultiplier;
    private float fov;
    private float originalSens;
    private float newSens;
    

    public Transform playerBody;
    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        fov = PlayerPrefs.GetFloat("fov", 85f);
        //thisCamera.fieldOfView = fov;
        
        mouseSens = PlayerPrefs.GetFloat("mouseSense", 100f);
        scopedMultiplier = PlayerPrefs.GetFloat("scopedMult", .85f);
        
        originalSens = mouseSens;
        newSens = mouseSens * scopedMultiplier;

        //thisCamera.fieldOfView = fov;
    }

    // Update is called once per frame
    void Update()
    {
        //thisCamera.fieldOfView = fov;

        if (Input.GetButton("Fire2"))
        {
            //Debug.Log("fire2");
            mouseSens = newSens;
        }
        else if (!Input.GetButtonDown("Fire2"))
        {
            //Debug.Log("!fire2");
            mouseSens = originalSens;
            thisCamera.fieldOfView = fov;
        }


        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;
        playerBody.Rotate(Vector3.up * mouseX);
        
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        //playerBody.Rotate(vector)
    }
    public void updateSettings() {
        fov = PlayerPrefs.GetFloat("fov", 85f);
        
        mouseSens = PlayerPrefs.GetFloat("mouseSense", 100f);
        scopedMultiplier = PlayerPrefs.GetFloat("scopedMult", .85f);

        originalSens = mouseSens;
        newSens = mouseSens * scopedMultiplier;
    }
}
