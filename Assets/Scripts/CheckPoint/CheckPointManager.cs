using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ecco.Core.Singleton;

public class CheckPointManager : Singleton<CheckPointManager>
{
    public int lastCheckPointKey = 0;

    public List<CheckPointBase> checkpoints;

    private void Start()
    {
        LoadCheckPointFromSetup();
    }

    private void LoadCheckPointFromSetup()
    {
        if(SaveManager.Instance.Setup != null)
        {
            if(SaveManager.Instance.Setup.lastcheckpoint > -1)
            {
                SaveCheckPoint(SaveManager.Instance.Setup.lastcheckpoint);
                Player.Instance.charaterController.enabled = false;
                Player.Instance.transform.position = GetPositionFromLastCheckPoint();
                Player.Instance.charaterController.enabled = true;
            }
        }
    }

    public bool HasCheckPoint()
    {
        return lastCheckPointKey > 0;
    }

    public void SaveCheckPoint(int i)
    {
        if (i > lastCheckPointKey)
        {
            lastCheckPointKey = i;
        }
    }

    public Vector3 GetPositionFromLastCheckPoint()
    {
        var checkpoint = checkpoints.Find(i => i.key == lastCheckPointKey);
        return checkpoint.transform.position;
    }
}
