using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance = null;
    public static UIManager Instance => instance;

    public Slider slider;
    private GameObject player;
    private void Start()
    {
        Observer.Instance.AddListaner(StringData.addDamagePlayer, UpdateHelthPlayer);
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Awake()
    {
        if(instance == null) { instance = this; }
        else if(instance.GetInstanceID() != this.GetInstanceID()) { Destroy(this); }
    }
    private void UpdateHelthPlayer()
    {
        var healthPlayer = player.GetComponent<HealthPlayerController>();
        slider.value = healthPlayer.health / healthPlayer.healthPlayer;
    }
}
