using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Volume_Control : MonoBehaviour
{
    public AudioMixer mixer;

    public void SetMASTER(float sliderValue)
    {
        mixer.SetFloat("Master_Volume", Mathf.Log10(sliderValue) * 20);
    }
    public void SetBGM(float sliderValue)
    {
        mixer.SetFloat("BGM_Volume", Mathf.Log10(sliderValue) * 20);
    }
    public void SetSFX(float sliderValue)
    {
        mixer.SetFloat("SFX_Volume", Mathf.Log10(sliderValue) * 20);
    }
}
