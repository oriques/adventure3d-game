using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase prefabProjectile;

    public Transform positionToShoot;
    public float timeBetweenShoot = .3f;
    public float speed = 50f;

    public List<string> tagsToIgnore = new List<string>();


    private Coroutine _currentCoroutine;

    protected virtual IEnumerator ShootCoroutine()
    {
        while(true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoot);
        }
    }


    public virtual void  Shoot()
    {
        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = positionToShoot.position;
        projectile.transform.rotation = positionToShoot.rotation;
        projectile.speedBullet = speed;
        projectile.tagsToIgnore.AddRange(tagsToIgnore);
    }


    public void StartShoot()
    {
        StopShoot();
        _currentCoroutine = StartCoroutine(ShootCoroutine());

    }
    public void StopShoot()
    {
       if (_currentCoroutine != null)
           StopCoroutine(_currentCoroutine);
    }
}
