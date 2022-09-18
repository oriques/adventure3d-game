using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityShoot : PlayerAbilityBase
{   
    public GunBase gunBase;
    public GunBase gunAngle;
    public GunBase gunLimit;
    public GunBase gunBibBig;
    public Transform gunPosition;
   
    private GunBase _currentGun;

    protected override void Init()
    {
        base.Init();

        CreateGun();

        inputs.Gameplay.Shoot.performed += ctx => StartShoot();
        inputs.Gameplay.Shoot.performed += ctx => CancelShoot();

        inputs.Gameplay.ChangeWeapon1.performed += ctx => ChangeGun1();
        inputs.Gameplay.ChangeWeapon2.performed += ctx => ChangeGun2();
        inputs.Gameplay.ChangeWeapon3.performed += ctx => ChangeGun3();
    }

   private void CreateGun()
    {
        _currentGun = Instantiate(gunBase, gunPosition);
        _currentGun.transform.localPosition = _currentGun.transform.localEulerAngles = Vector3.zero;
    }

    private void StartShoot()
    {
        _currentGun.StartShoot();
        Debug.Log("Shoot");
    }
    private void CancelShoot()
    {
        Debug.Log("Cancel");
        _currentGun.StopShoot();
    }
    private void ChangeGun1()
    {
        _currentGun = Instantiate(gunLimit, gunPosition);
    }
    private void ChangeGun2()
    {
        _currentGun = Instantiate(gunAngle, gunPosition);
    }
    private void ChangeGun3()
    {
        _currentGun = Instantiate(gunBibBig, gunPosition);
    }
}
