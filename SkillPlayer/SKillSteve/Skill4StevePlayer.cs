using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill4StevePlayer : MonoBehaviour
{
    public bool triggerSkill4 = false;
    private void OnEnable() => triggerSkill4 = true;
    private void OnDisable() => triggerSkill4 = false;
    public void triggerSkill() => this.gameObject.SetActive(true);
    public void endTriggerSkill() => this.gameObject.SetActive(false);
}
