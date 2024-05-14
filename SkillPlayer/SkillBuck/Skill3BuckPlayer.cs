using UnityEngine;


public class Skill3BuckPlayer : MonoBehaviour
{
    public Animator animatorPlayer;
    private void OnEnable()
    {
        animatorPlayer.SetFloat("ValueAttach", 1);
        //this.transform.parent.GetComponent<playerController>().timeAttachPlayer = 0.4f;
        this.transform.parent.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;
    }
    private void OnDisable()
    {
        animatorPlayer.SetFloat("ValueAttach", 0);
        //this.transform.parent.GetComponent<playerController>().timeAttachPlayer = 0.75f;
        this.transform.parent.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
    }
    public void triggerSkill() => this.gameObject.SetActive(true);
    public void endTriggerSkill() => this.gameObject.SetActive(false);
}

