using UnityEngine;

public class Skill2BuckPlayer : MonoBehaviour
{
    private HealthPlayerController healthPlayerController;
    private void OnEnable()
    {
        this.GetComponent<SpriteRenderer>().enabled = true;
        healthPlayerController = this.transform.parent.GetComponent<HealthPlayerController>();
        healthPlayerController.isAmor = true;
    }
    private void OnDisable()
    {
        healthPlayerController.isAmor = false;
    }
    public void triggerSkill() => this.gameObject.SetActive(true);
    public void endTriggerSkill() => this.gameObject.SetActive(false);
    public void SetEndAniamtion() => this.GetComponent<SpriteRenderer>().enabled = false;
}
