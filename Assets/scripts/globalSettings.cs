using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class globalSettings : MonoBehaviour
{
    /*
    public float mouseSense;
    public float scopedMult;
    public double fov;
    */
    // Start is called before the first frame update
    public void change_mouseSense(float new_mouseSense) {
        Debug.Log("change_mouseSense = " + new_mouseSense);
        PlayerPrefs.SetFloat("mouseSense", new_mouseSense);
        PlayerPrefs.Save();
        //mouseSense = new_mouseSense;
    }

    public void change_scopedMult(float new_scopedMult){
        Debug.Log("change_scopedMult = " + new_scopedMult);
        PlayerPrefs.SetFloat("scopedMult", new_scopedMult);
        PlayerPrefs.Save();
        //scopedMult = new_scopedMult;
    }
    public void changeFov(float newFov) {
        Debug.Log("changeFov = " + newFov);
        PlayerPrefs.SetFloat("fov", newFov);
        PlayerPrefs.Save();
        //fov = newFov;
    }

    public void changeVolume(float newVolume) {
        Debug.Log("changeVolume =" + newVolume);
        PlayerPrefs.SetFloat("volume", newVolume);
        PlayerPrefs.Save();
    }
    void Start()
    {
        //DontDestroyOnLoad(this.gameObject);
    }
}
