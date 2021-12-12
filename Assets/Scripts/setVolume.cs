using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class setVolume : MonoBehaviour
{

    public AudioMixer masterVol;
    public Slider slider; 

    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("mainVolume", 0.5f);
    }

    public void SetLevel(float sliderValue)
    {
        masterVol.SetFloat("mainVolume", Mathf.Log10(sliderValue) * 20);

        PlayerPrefs.SetFloat("mainVolume", sliderValue);
    }
}
