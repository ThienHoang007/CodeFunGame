using UnityEngine;

namespace SKillBuck
{
    public class skill1BuckPlayer : MonoBehaviour
    {
        private void OnEnable()
        {
            this.transform.parent.GetComponent<playerController>().SpeedPlayer *= 2;
            this.transform.parent.GetChild(0).GetComponent<Animator>().SetFloat("valueRun", 1);
        }
        private void OnDisable()
        {
            this.transform.parent.GetComponent<playerController>().SpeedPlayer /= 2;
            this.transform.parent.GetChild(0).GetComponent<Animator>().SetFloat("valueRun", 0);
        }
        public void triggerSkill() => this.gameObject.SetActive(true);
        public void endTriggerSkill() => this.gameObject.SetActive(false);
    }
}
