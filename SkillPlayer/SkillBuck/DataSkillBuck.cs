using UnityEngine;

[CreateAssetMenu(menuName = "Data/Buck", fileName = "dataSkill")]
public class DataSkillBuck : ScriptableObject
{
    public int ValueSkill;
    public float TimeCooldownStart;
    public float TimeTriggerStart;
    public Texture Image;
}
