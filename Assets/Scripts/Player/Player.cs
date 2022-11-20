using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ecco.Core.Singleton;

public class Player : Singleton<Player>
{ 

    public Animator animator;
    public List<Collider> colliders;

    public CharacterController charaterController;
    public float speed = 1f;
    public float turnSpeed = 1f;
    public float gravity = 9.8f;
    public float jumpSpeed = 15f;
    public float speedRun = 1.5f;

    [Header("Input Key")]
    public KeyCode keyRun = KeyCode.LeftShift;
    public KeyCode keyJump = KeyCode.Space;

    private float vSpeed = 0f;

    [Header("Flash")]
    public List<FlashColor> flashColors;

    [Header("Life")]
    public HealthBase healthBase;
    public float timeToRevive = 7f;

    private bool _alive = true;

    private void OnValidate()
    {
        if (healthBase == null) healthBase = GetComponent<HealthBase>();
    }

    protected override void Awake()
    {
        base.Awake();

        OnValidate();

        healthBase.OnDamage += Damage;
        healthBase.OnKill += OnKill;
    }


    #region LIFE
    private void OnKill (HealthBase h)
    {
       if (_alive)
        {
            _alive = false;
            animator.SetTrigger("Death");
            colliders.ForEach(i => i.enabled = false);

            Invoke(nameof(Revive), timeToRevive);
        }
    }

    private void Revive()
    {
        _alive = true;
        healthBase.ResetLife();
        animator.SetTrigger("Revive");
        Respawn();
        colliders.ForEach(i => i.enabled = true);

    }

    public void Damage(HealthBase h)
    {
        flashColors.ForEach(i => i.Flash());
        EffectsManager.Instance.ChangeVignette();
        ShakeCamera.Instance.Shake();
    }

    public void Damage(float damage, Vector3 dir)
    {
     //  Damage(damage);
    }
    #endregion

    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);

        var inputAxisVertical = Input.GetAxis("Vertical");
        var speedVector = transform.forward * inputAxisVertical * speed;

        if(charaterController.isGrounded)
        {
            vSpeed = 0;
            if (Input.GetKeyDown(keyJump))
            {
                vSpeed = jumpSpeed;
            }
        }

        var isWalking = inputAxisVertical != 0;
        if(isWalking)
        {
            if(Input.GetKey(keyRun))
            {
                speedVector *= speedRun;
                animator.speed = speedRun;
            }
            else
            {
                animator.speed = 1;
            }
        }
         


        vSpeed -= gravity * Time.deltaTime;
        speedVector.y = vSpeed;

        charaterController.Move(speedVector * Time.deltaTime);

        animator.SetBool("Run", isWalking);
    }

    [NaughtyAttributes.Button]
    public void Respawn()
    {
        if(CheckPointManager.Instance.HasCheckPoint())
        {
            transform.position = CheckPointManager.Instance.GetPositionFromLastCheckPoint();
        }
    }
}
