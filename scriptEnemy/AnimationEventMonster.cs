using UnityEngine;

public class AnimationEventMonster : MonoBehaviour
{
    private GameObject player;
    private RaycastHit2D hit;
    private void Start()
    {
        player = GameObject.Find("player");
    }
    public void EndAnimationMonster() => this.gameObject.GetComponent<AnimationMonster>().stateMonster = AnimationMonster.MonsterState.Idle;
    public void MonsterDie()
    {
        this.gameObject.SetActive(false);
        MonsterManager.Instance.valueMonster--;
    }
    public void AddDamageForPlayer()
    {
        hit = Physics2D.Raycast(this.transform.position, new Vector2(this.transform.localScale.x, -0.4f), 2.5f);
        if(hit.collider != null && hit.collider.gameObject.CompareTag("Player"))
        player.GetComponent<HealthPlayerController>().addDamageForPlayer(this.GetComponent<MonsterController>().damageMonster);
    }
}
