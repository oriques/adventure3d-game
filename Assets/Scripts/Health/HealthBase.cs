using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Animation;

public class HealthBase : MonoBehaviour, IDamageable
{
    public float timeToDestroy = 3f;
    public float startLife = 10f;
    public bool destroyOnKill = false;
    [SerializeField] private float _currentLife;

    public Action<HealthBase> OnDamage;
    public Action<HealthBase> OnKill;

    public List<UIFillUpdater> uiFillUpdater;


    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        ResetLife();
    }


    public void ResetLife()
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
        UpdateUI();
        OnDamage?.Invoke(this);
    }

    public void Damage(float damage, Vector3 dir)
    {
        Damage(damage);
    }

    private void UpdateUI()
    {
        if(uiFillUpdater != null)
        {
            uiFillUpdater.ForEach(i => i.UpdateValue((float) _currentLife / startLife));
        }
    }
}
