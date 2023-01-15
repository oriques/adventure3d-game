using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioChangeVolume : MonoBehaviour
{
    public AudioMixer group;
    public string floatParam = "";
    public Slider slider;

    public void ChangeValue(float f)
    {
        group.SetFloat(floatParam, slider.value);
    }


}
