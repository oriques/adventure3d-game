using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Animation;

public class HealthBase : MonoBehaviour
{
    public float timeToDestroy = 3f;
    public float startLife = 10f;
    public bool destroyOnKill = false;
    [SerializeField] private float _currentLife;

   

    public Action<HealthBase> OnDamage;
    public Action<HealthBase> OnKill;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        ResetLife();
    }


    protected void ResetLife()
    {
        _currentLife = startLife;
    }

    protected virtual void Kill()
    {
        if (destroyOnKill)
            Destroy(gameObject, timeToDestroy);

        OnKill?.Invoke(this);
    }

    [NaughtyAttributes.Button]
    public void Damage()
    {
        Damage(5);
    }


    public void Damage(float f)
    {
        _currentLife -= f;

        if (_currentLife <= 0)

        {
            Kill();
        }
        OnDamage?.Invoke(this);
    }

}
