using SKillBuck;
using Unity.VisualScripting;
using UnityEngine;

public class skillControllerAction : MonoBehaviour
{
    public GameObject skill1;
    public GameObject skill2;   
    public GameObject skill3;
    public GameObject skill4;
    private void Start()
    {
        switch(PlayerPrefs.GetInt(StringData.idCharacter))
        {
            case 1:
                supEventBuck();
                supEventBuckEnd();
                break;
            case 2:
                supEventSteve();
                supEventSteveEnd();
                break;
        }
    }
    private void supEventSteve()
    {
        Observer.Instance.AddListaner($"{PlayerPrefs.GetInt(StringData.idCharacter)}skill{1}Start", skill1.GetComponent<Skill1StevePlayer>().triggerSkill);
        Observer.Instance.AddListaner($"{PlayerPrefs.GetInt(StringData.idCharacter)}skill{2}Start", skill2.GetComponent<Skill2StevePlayer>().triggerSKill);
        Observer.Instance.AddListaner($"{PlayerPrefs.GetInt(StringData.idCharacter)}skill{3}Start", skill3.GetComponent<Skill3StevePlayer>().triggerSkill);
        Observer.Instance.AddListaner($"{PlayerPrefs.GetInt(StringData.idCharacter)}skill{4}Start", skill4.GetComponent<Skill4StevePlayer>().triggerSkill);
    }
    private void supEventSteveEnd()
    {
        Observer.Instance.AddListaner($"{PlayerPrefs.GetInt(StringData.idCharacter)}skill{1}End", skill1.GetComponent<Skill1StevePlayer>().endTriggerSkill);
        Observer.Instance.AddListaner($"{PlayerPrefs.GetInt(StringData.idCharacter)}skill{2}End", skill2.GetComponent<Skill2StevePlayer>().endTriggerSkill);
        Observer.Instance.AddListaner($"{PlayerPrefs.GetInt(StringData.idCharacter)}skill{3}End", skill3.GetComponent<Skill3StevePlayer>().endTriggerSkill);
        Observer.Instance.AddListaner($"{PlayerPrefs.GetInt(StringData.idCharacter)}skill{4}End", skill4.GetComponent<Skill4StevePlayer>().endTriggerSkill);
    }
    private void removeEvent()
    {
        for(int i = 0; i < 4; i++)
        {
            Observer.Instance.removeListener($"{PlayerPrefs.GetInt(StringData.idCharacter)}skill{i+ 1}Start");
            Observer.Instance.removeListener($"{PlayerPrefs.GetInt(StringData.idCharacter)}skill{i + 1}End");
        }
    }
    private void supEventBuck()
    {
        Observer.Instance.AddListaner($"{PlayerPrefs.GetInt(StringData.idCharacter)}skill{1}Start", skill1.GetComponent<skill1BuckPlayer>().triggerSkill);
        Observer.Instance.AddListaner($"{PlayerPrefs.GetInt(StringData.idCharacter)}skill{2}Start", skill2.GetComponent<Skill2BuckPlayer>().triggerSkill);
        Observer.Instance.AddListaner($"{PlayerPrefs.GetInt(StringData.idCharacter)}skill{3}Start", skill3.GetComponent<Skill3BuckPlayer>().triggerSkill);
        Observer.Instance.AddListaner($"{PlayerPrefs.GetInt(StringData.idCharacter)}skill{4}Start", skill4.GetComponent<Skill4BuckPlayer>().triggerSkill);
    }
    private void supEventBuckEnd()
    {
        Observer.Instance.AddListaner($"{PlayerPrefs.GetInt(StringData.idCharacter)}skill{1}End", skill1.GetComponent<skill1BuckPlayer>().endTriggerSkill);
        Observer.Instance.AddListaner($"{PlayerPrefs.GetInt(StringData.idCharacter)}skill{2}End", skill2.GetComponent<Skill2BuckPlayer>().endTriggerSkill);
        Observer.Instance.AddListaner($"{PlayerPrefs.GetInt(StringData.idCharacter)}skill{3}End", skill3.GetComponent<Skill3BuckPlayer>().endTriggerSkill);
        Observer.Instance.AddListaner($"{PlayerPrefs.GetInt(StringData.idCharacter)}skill{4}End", skill4.GetComponent<Skill4BuckPlayer>().endTriggerSKill);
    }
    private void OnDestroy()
    {
        removeEvent();
    }
}
