using System;
using System.Collections;
using UnityEngine;

public class AnimationMonster : MonoBehaviour
{
    public enum MonsterState { Walk, Run, Idle, Attach, Die, TakeDamage }
    private Animator AnimatorMonster;
    public MonsterState stateMonster;
    // Start is called before the first frame update
    void Start()
    {
        AnimatorMonster = GetComponent<Animator>();
        this.enabled = false;
        StartCoroutine(delay());
    }
    // Update is called once per frame
    void Update()
    {
        SetAnimationAccorStateMonster(SetStateMonster());
    }

    private void SetAnimationAccorStateMonster(MonsterState State)
    {
        for(int i = 0; i <= MaxStateMonster(); i++)
        {
            if(State == (MonsterState)i) AnimatorMonster.SetBool(((MonsterState)i).ToString(), true);
            else AnimatorMonster.SetBool(((MonsterState)i).ToString(), false);
        }
    }
    private int MaxStateMonster()
    {
        MonsterState[] states = (MonsterState[])Enum.GetValues(typeof(MonsterState));
        return (int)states[states.Length - 1];
    }
    private MonsterState SetStateMonster()
    {
        if(stateMonster == MonsterState.Die) return MonsterState.Die;
        else if (stateMonster == MonsterState.Attach) return MonsterState.Attach;
        else if (stateMonster == MonsterState.TakeDamage) return MonsterState.TakeDamage;
        else if (this.gameObject.GetComponent<Rigidbody2D>().velocity.x != 0) return MonsterState.Run;
        else return MonsterState.Idle;
    }
    private IEnumerator delay()
    {
        yield return new WaitForSeconds(0.5f);
        this.enabled = true;
    }
}
