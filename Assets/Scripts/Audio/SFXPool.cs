using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ecco.Core.Singleton;

public class SFXPool : Singleton<SFXPool>
{
    public List<AudioSource> _audioSourceList;

    public int poolSize = 10;
    private int _index = 0;

    private void Start()
    {
        CreatePool();

    }

    private void CreatePool()
    {
        _audioSourceList = new List<AudioSource>();
        for (int i = 0; i < poolSize; i++)
        {
            CreateAudioSoucerItem();
        }

    }

    private void CreateAudioSoucerItem()
    {
        GameObject go = new GameObject("SFXPool");
        go.transform.SetParent(gameObject.transform);
        _audioSourceList.Add(go.AddComponent<AudioSource>());
    }

    public void Play(SFXType sfxType)
    {
        if (sfxType == SFXType.NONE) return;
        var sfx = AudioManager.Instance.GetSFXByType(sfxType);
        _audioSourceList[_index].clip = sfx.audioClip;
        _audioSourceList[_index].Play();

        _index++;
        if (_index >= _audioSourceList.Count) _index = 0;
    }



}
