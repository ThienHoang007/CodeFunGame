using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SkillController : MonoBehaviour
{
    [Header("Set Your Skill")]
    [SerializeField] private float TimeTriggerStart;

    [SerializeField] private Texture image;
    [SerializeField] private Image imageCooldown;
    [SerializeField] private Text textCooldown;

    [SerializeField] private UnityEvent OnTriggerStart;
    [SerializeField] private UnityEvent OnTriggerEnd;

    [SerializeField] private int ValueSkill;

    public enum keycode { H, J, K, L };
    public keycode key;

    private UnityAction action;
    private float TimeTrigger;
    private float TimeCooldown;
    private bool isTriggerSkill = true;

    // Start is called before the first frame update
    void Start()
    {
        LoadData(SkillManager.Instance.GetListDataSkill(PlayerPrefs.GetInt(StringData.idCharacter)), ValueSkill);
        imageCooldown.fillAmount = 0;
        textCooldown.text = null;
        action = OnStartSkill;

        OnTriggerStart.AddListener(startSkill);
        OnTriggerEnd.AddListener(endSKill);
    }

    // Update is called once per frame
    void Update()
    {
        triggerSkill();
        OnUpdateImageAndText();
    }
    private void triggerSkill()
    {
        if(Input.GetKeyDown(GetKeyCode(key)) && isTriggerSkill)
        {
            action?.Invoke();
        }
    }
    private void OnUpdateImageAndText()
    {
        if(!isTriggerSkill)
        {
            TimeTrigger -= Time.deltaTime;
            imageCooldown.fillAmount = TimeTrigger / TimeTriggerStart;
            textCooldown.text = ((int)TimeTrigger).ToString();
        }
    }
    private void OnEndSkill()
    {
        isTriggerSkill = true;
        TimeTrigger = TimeTriggerStart;
        textCooldown.text = null;
        imageCooldown.fillAmount = 0;
    }
    private void OnStartSkill()
    {
        isTriggerSkill = false;
        OnTriggerStart?.Invoke();
        StartCoroutine(TimeTriggerSkill());
        StartCoroutine(TimeCooldownSkill());
    }
    private KeyCode GetKeyCode(keycode key)
    {
        switch(key) {
            case keycode.H: return KeyCode.H;
            case keycode.J: return KeyCode.J;
            case keycode.K: return KeyCode.K;
            case keycode.L: return KeyCode.L;
            default: return KeyCode.None;
        }
    }
    private void startSkill()
    {
        Observer.Instance.Notify($"{PlayerPrefs.GetInt(StringData.idCharacter)}skill{ValueSkill}Start");
    }
    private void endSKill()
    {
        Observer.Instance.Notify($"{PlayerPrefs.GetInt(StringData.idCharacter)}skill{ValueSkill}End");
    }
    public void LoadData(List<DataSkillBuck> data, int value)
    {
        foreach(var skill in data)
        {
            if(value == skill.ValueSkill)
            {
                this.TimeTriggerStart = skill.TimeTriggerStart;
                TimeTrigger = skill.TimeTriggerStart;
                TimeCooldown = skill.TimeCooldownStart;
                this.transform.GetChild(0).GetComponent<RawImage>().texture = skill.Image;
                break;
            }
        }
    }
    private IEnumerator TimeTriggerSkill()
    {
        yield return new WaitForSeconds(TimeTriggerStart);
        OnEndSkill();
    }
    private IEnumerator TimeCooldownSkill()
    {
        yield return new WaitForSeconds(TimeCooldown);
        OnTriggerEnd?.Invoke();
    }

}
