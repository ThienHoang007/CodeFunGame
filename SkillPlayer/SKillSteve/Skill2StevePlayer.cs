using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill2StevePlayer : MonoBehaviour
{
    [SerializeField] private Animator animator;
    void OnEnable() => animator.SetBool("Skill2", true);
    void OnDisable() => animator.SetBool("Skill2", false);
    private void DeactiveSkill2()
    {
        this.transform.parent.GetComponent<playerController>().DamagePlayer -= 1000f;
        this.gameObject.SetActive(false);
    }
    public void triggerSKill()
    {
        this.transform.parent.GetComponent<playerController>().DamagePlayer += 1000f;
        this.gameObject.SetActive(true);
    }
    public void endTriggerSkill() => print("end!");
}
