using UnityEngine.UI;
using UnityEngine;
using static MonsterBase;

public class controllerHealthMonster : MonoBehaviour
{
    [HideInInspector] public float health;
    [HideInInspector] public float maxHealth;
    public Animation clip;
    public AnimationMonster Monster;
    public Text text;
    public Slider slider;
    public DataMonster dataMonster;

    private void Start()
    {
        maxHealth = dataMonster.Health;
        health = maxHealth;
    }
    public void takeDamageAndDie_Monster(float damage)
    {
        if(health > 0)
        {
            Monster.stateMonster = AnimationMonster.MonsterState.TakeDamage;
            health -= damage;
            UpdateSlider(health / maxHealth, slider);
            UpdateText(damage, text);
            clip.Play();
            return;
        }
        Monster.stateMonster = AnimationMonster.MonsterState.Die;
    }
    private void UpdateText(float value, Text text) => text.text = value.ToString();
    private void UpdateSlider(float value, Slider slider) => slider.value = value;
}
