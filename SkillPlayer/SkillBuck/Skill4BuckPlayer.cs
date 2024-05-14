using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Skill4BuckPlayer : MonoBehaviour
{
    public bool isSkill4 = false;
    private void OnEnable()
    {
        isSkill4 = true;
    }
    private void OnDisable()
    {
        isSkill4 = false;
    }
    public void triggerSkill() => this.gameObject.SetActive(true);
    public void endTriggerSKill() => this.gameObject.SetActive(false);
}
