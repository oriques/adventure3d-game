using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DestructableItemBase : MonoBehaviour
{
    public HealthBase healthBase;

    public float shakeDuration = .1f;
    public int shakeForce = 1;
    public Vector2 randomRange = new Vector2(-2f, 2f);

    public int dropCoinsAmount = 10;
    public GameObject coinPrefab;
    public Transform dropPosition;
    

    private void OnValidate()
    {
        if (healthBase == null) healthBase = GetComponent<HealthBase>();

    }

    private void Awake()
    {
        OnValidate();
        healthBase.OnDamage += OnDamage;

    }

    private void OnDamage(HealthBase h)
    {
        transform.DOShakeScale(shakeDuration, Vector3.up/4, shakeForce);
        DropGroupOfCoins();
    }

    [NaughtyAttributes.Button]
    private void DropCoins()
    {
        var i = Instantiate(coinPrefab);

        i.transform.position = dropPosition.position + Vector3.forward * Random.Range(randomRange.x, randomRange.y) + Vector3.right * Random.Range(randomRange.x, randomRange.y);
        i.transform.DOScale(0, .2f).SetEase(Ease.OutBack).From();
    }

    [NaughtyAttributes.Button]
    private void DropGroupOfCoins()
    {
        StartCoroutine(DropGroupOfCoinsCoroutine());
    }
    IEnumerator DropGroupOfCoinsCoroutine()
    {
        for (int i = 0; i < dropCoinsAmount; i++)
        {
            DropCoins();
            yield return new WaitForSeconds(.1f);
        }
    }


}
