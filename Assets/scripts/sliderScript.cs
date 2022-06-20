using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider volume;
    public Slider mouseSense;
    public Slider scopedMult;
    public Slider FOV;


    void Start()
    {
        volume.value = PlayerPrefs.GetFloat("volume", 100);
        mouseSense.value = PlayerPrefs.GetFloat("mouseSense", 200);
        scopedMult.value = PlayerPrefs.GetFloat("scopedMult", .85f);
        FOV.value = PlayerPrefs.GetFloat("fov", 85);

    }

}
