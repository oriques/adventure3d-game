using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ecco.StateMachine;


namespace Boss
{
    public class BossStateBase : StateBase
    {

        public BossBase boss;

        public override void OnStateEnter(params object[] objs)
        {
            base.OnStateEnter(objs);
            boss = (BossBase)objs[0];
        }
    }

    public class BossStateInit : BossStateBase
    {
        public override void OnStateEnter(params object[] objs)
        {
            base.OnStateEnter(objs);
            boss.StartInitAnitmation();
           
        }

    }

    public class BossStateWalk : BossStateBase
    {
        public override void OnStateEnter(params object[] objs)
        {
            base.OnStateEnter(objs);
            boss.GoToRandomPoint(OnArrive);
       
        }

        private void OnArrive()
        {
            boss.SwitchState(BossAction.ATTACK);
        }

        public override void OnStateExit()
        {
            Debug.Log("Walk attack");
            base.OnStateExit();
            boss.StopAllCoroutines();
        }

    }
    
    public class BossStateAttack : BossStateBase
    {
        public override void OnStateEnter(params object[] objs)
        {
            base.OnStateEnter(objs);
            boss.StartAttack(EndAttacks);
       
        }

        private void EndAttacks()
        {
            boss.SwitchState(BossAction.WALK);
        }
        public override void OnStateExit()
        {
            Debug.Log("Exit attack");
            base.OnStateExit();
            boss.StopAllCoroutines();
        }

    }    
    
    public class BossStateDeath : BossStateBase
    {
        public override void OnStateEnter(params object[] objs)
        {
            base.OnStateEnter(objs);
            Debug.Log("Death ");
            boss.transform.localScale = Vector3.one * .5f;   
        }
    }

}