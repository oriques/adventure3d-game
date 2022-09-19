using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class GunShootBigbig : GunShootLimit
{

    public int amountPerShoot = 1;
    public float size = 4f;
    //public float duration = 0.1f;
    //private Tween _projectTween;

    public override void Shoot()
    {
       for(int i = 0; i< amountPerShoot; i++)
        {

            //if (_projectTween != null) _projectTween.Kill();
            // _projectTween = prefabProjectile.transform.DOScale(Vector3.zero * size, duration);


            var projectile = Instantiate(prefabProjectile, positionToShoot);
                        
            projectile.transform.localPosition = positionToShoot.transform.localPosition * 3;
            //projectile.transform.localScale = prefabProjectile.transform.DOScale(Vector3.zero * size, duration);
            projectile.transform.localScale = Vector3.one * size;
           
            projectile.speedBullet = speed;
            projectile.transform.parent = null;

        }


    }

}
