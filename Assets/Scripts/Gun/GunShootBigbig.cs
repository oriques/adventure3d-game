using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShootBigbig : GunShootLimit
{

    public int amountPerShoot = 1;
    public float size = 4f;

    public override void Shoot()
    {
       for(int i = 0; i< amountPerShoot; i++)
        {

           var projectile = Instantiate(prefabProjectile, positionToShoot);

            
            projectile.transform.localPosition = positionToShoot.transform.localPosition * 3;
            projectile.transform.localScale = Vector3.one * size;

            projectile.speedBullet = speed;
            projectile.transform.parent = null;

        }


    }

}
