using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill3StevePlayer : MonoBehaviour
{
    [SerializeField] GameObject game;
    private void OnEnable()
    {
        Instantiate(game, this.transform.parent.transform.position, Quaternion.identity);
    }
    public void triggerSkill() => this.gameObject.SetActive(true);
    public void endTriggerSkill() => print("end!");
}
