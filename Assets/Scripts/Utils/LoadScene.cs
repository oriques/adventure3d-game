using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
   public void LoadLevel(int level)
    {
 
        SceneManager.LoadScene(level);
        
    }

    public void LoadLastLevel ()
    {
        var last = (SaveManager.Instance.lastLevel) + (1);
        SceneManager.LoadScene(last);
    }
}
