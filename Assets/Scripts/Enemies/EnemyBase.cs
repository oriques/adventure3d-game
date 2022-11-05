using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Animation;


namespace Enemy
{
    public class EnemyBase : MonoBehaviour, IDamageable 
    {

        public Collider colliderEnemy;
        public FlashColor flashColor;
        public ParticleSystem particleSystemEnemy;
        public float startLife = 10f;
        public bool lookAtPlayer = false;
       
        public float timeToDestroy = 3f;
        
        [SerializeField] private float _currentLife;


        [Header("Animation")]
        [SerializeField] private AnimationBase _animationBase;

        [Header("Start Animation")]
        public float startAnimationDuration = .2f;
        public Ease startAnimationEase = Ease.OutElastic;
        public bool startWithBornAnimation = true;

        private Player _player;

        private void Awake()
        {
            Init();
        }

        private void Start()
        {
            _player = GameObject.FindObjectOfType<Player>();
        }

        protected void ResetLife()
        {
            _currentLife = startLife;
        }

        protected virtual void Init()
        {
            ResetLife();
            if(startWithBornAnimation)
                BornAnimation();
        }
        protected virtual void Kill()
        {
            OnKill();
        }

        protected virtual void OnKill()
        {
            if (colliderEnemy != null) colliderEnemy.enabled = false;
            Destroy(gameObject, timeToDestroy);
            PlayAnimationByTrigger(AnimationType.DEATH);
        }

        public void OnDamage (float f)
        {
            if (flashColor != null) flashColor.Flash();
            if (particleSystemEnemy != null) particleSystemEnemy.Emit(15);

            transform.position -= transform.forward;
            _currentLife -= f;

            if(_currentLife <= 0)
            {
                Kill();
            }
        }

        #region ANIMATION

        private void BornAnimation()
        {
            transform.DOScale(0, startAnimationDuration).SetEase(startAnimationEase).From();
        }

        public void PlayAnimationByTrigger(AnimationType animationType)
        {
            _animationBase.PlayAnimationByTrigger(animationType);

        }
        #endregion

        //debug
        public void Damage(float damage)
        {
            Debug.Log("Damage");
            OnDamage(damage);
        }
        public void Damage(float damage, Vector3 dir)
        {
            OnDamage(damage);
            transform.DOMove(transform.position - dir, 1f);
        }

        private void OnCollisionEnter(Collision collision)
        {
            Player p = collision.transform.GetComponent<Player>();

            if (p != null)
            {
                p.healthBase.Damage(1);
            }
        }
            public virtual void Update()
            {
                if (lookAtPlayer)
                {
                    transform.LookAt(_player.transform.position);
                }
            }
    }
}