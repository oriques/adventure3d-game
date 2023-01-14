using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointBase : MonoBehaviour
{
    public SFXType sfxType;
    public MeshRenderer meshRenderer;
    public int key = 01;

    private bool checkPointActived = false;
   // private string checkPointKey = "CheckPointKey";

    private void OnTriggerEnter(Collider other)
    {
        if (!checkPointActived && other.transform.tag == "Player")
        { 
            CheckPointCheck();

        }
    }
    private void PlaySFX()
    {
        SFXPool.Instance.Play(sfxType);
    }
    private void CheckPointCheck()
    {
        SaveCheckPoint();
        TurnItOn();
        PlaySFX();
    }

    [NaughtyAttributes.Button]
    private void TurnItOn()
    {
        meshRenderer.material.SetColor("_EmissionColor", Color.white);
    }
    [NaughtyAttributes.Button]
    private void TurnItOff()
    {
        meshRenderer.material.SetColor("_EmissionColor", Color.black);
    }

    private void SaveCheckPoint()
    {
        /*if (PlayerPrefs.GetInt(checkPointKey, 0) > key)
            PlayerPrefs.SetInt(checkPointKey, key);*/

        CheckPointManager.Instance.SaveCheckPoint(key);

        checkPointActived = true;
    }

}
