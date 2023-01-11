using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSaveFileHelper : MonoBehaviour
{
   public void DeleteSaveFile()
    {
        SaveManager.Instance.DeleteSaveFile();
    }
}
