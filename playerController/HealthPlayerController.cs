using UnityEngine;
public class HealthPlayerController : MonoBehaviour
{
    [SerializeField] DataPlayer player;
    public float healthPlayer { get; private set; }
    public float health { get; private set; }
    public bool isAmor = false;
    private void Start()
    {
        healthPlayer = player.Health;
        health = healthPlayer;
    }
    public void addDamageForPlayer(float damage)
    {
        if (health - damage <= 0)
        {
            health = 0;
            Observer.Instance.Notify(StringData.addDamagePlayer);
            this.GetComponent<playerController>().playerState = PlayerControllerBase.PlayerState.Die;
            return;
        }
        if (isAmor) damage = damage - damage * 0.7f;
        health -= damage;
        Observer.Instance.Notify(StringData.addDamagePlayer);
    }
    public void takeHealthForPlayer(float health)
    {
        if (health == healthPlayer) return;
        this.health += health;
        Observer.Instance.Notify(StringData.addDamagePlayer);
    }
    private void OnDestroy()
    {
        Observer.Instance.removeListener(StringData.addDamagePlayer);
    }
}
