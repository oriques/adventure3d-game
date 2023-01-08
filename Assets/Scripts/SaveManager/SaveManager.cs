using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ecco.Core.Singleton;

public class SaveManager : Singleton<SaveManager>
{

    private SaveSetup _saveSetup;

    protected override void Awake()
    {
        base.Awake();
        _saveSetup = new SaveSetup();
        _saveSetup.lastLevel = 2;
        _saveSetup.playerName = "Oriques";
    }

    #region SAVE
    [NaughtyAttributes.Button]
    public void Save()
    {
        SaveSetup setup = new SaveSetup();
        setup.lastLevel = 2;
        setup.playerName = "Oriques";

        string setupToJson = JsonUtility.ToJson(setup);
        Debug.Log(setupToJson);
        SaveFile(setupToJson);
    }

    public void SaveName (string text)
    {
        _saveSetup.playerName = text;
        Save();
    }

    public void SaveLastLevel(int level)
    {
        _saveSetup.lastLevel = level;
        Save();
    }
    #endregion

    private void SaveFile(string json)
    {
        string path = Application.dataPath + "/save.txt";

        Debug.Log(path);
        File.WriteAllText(path, json);
    }

    [NaughtyAttributes.Button]
    private void SavelLevelOne()
    {
        SaveLastLevel(1);
    }
}

[System.Serializable]
public class SaveSetup
{
    public int lastLevel;
    public string playerName;

}