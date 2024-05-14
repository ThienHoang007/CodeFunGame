//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class AnimationMonsterFly : MonoBehaviour
//{
//    private FlyMonsterControllerG Monster;
//    private Animator AnimatorMonster;
//    private MonsterController.MonsterState MonsterState;
//    // Start is called before the first frame update
//    void Start()
//    {
//        Monster = this.gameObject.GetComponent<FlyMonsterControllerG>();
//        AnimatorMonster = GetComponent<Animator>();
//    }
//    // Update is called once per frame
//    void Update()
//    {
//        SetStateMonster();
//        SetAnimationAccorStateMonster(MonsterState);
//    }

//    private void SetAnimationAccorStateMonster(MonsterController.MonsterState State)
//    {
//        for (int i = 0; i <= MaxStateMonster(); i++)
//        {
//            if (State == (MonsterController.MonsterState)i) AnimatorMonster.SetBool(((MonsterController.MonsterState)i).ToString(), true);
//            else AnimatorMonster.SetBool(((MonsterController.MonsterState)i).ToString(), false);
//        }
//    }
//    private int MaxStateMonster()
//    {
//        MonsterController.MonsterState[] states = (MonsterController.MonsterState[])Enum.GetValues(typeof(MonsterController.MonsterState));
//        return (int)states[states.Length - 1];
//    }
//    private void SetStateMonster()
//    {
//        if (Monster.StateMonster == MonsterController.MonsterState.Die) MonsterState = MonsterController.MonsterState.Die;
//        else if (Monster.StateMonster == MonsterController.MonsterState.Attach) MonsterState = MonsterController.MonsterState.Attach;
//        else if (Monster.StateMonster == MonsterController.MonsterState.TakeDamage) MonsterState = MonsterController.MonsterState.TakeDamage;
//        else MonsterState = MonsterController.MonsterState.Idle;
//    }
//}
