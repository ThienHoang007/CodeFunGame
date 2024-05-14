using System.Collections.Generic;
using UnityEngine;

public class Skill1StevePlayer : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private RaycastHit2D[] hit;
    private List<int> idEnemy = new List<int>();
    private SpriteRenderer SpriteRenderer;
    private float speedPlayer;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnEnable() => animator.SetBool("Skill1", true);
    void OnDisable() => animator.SetBool("Skill1", false);

    // Update is called once per frame
    void Update()
    {
        hit = Physics2D.RaycastAll(this.transform.position, this.transform.parent.localScale.x > 0 ? new Vector2(1, 0) : new Vector2(-1, 0), SpriteRenderer.bounds.size.x);
        print(SpriteRenderer.bounds.size.x);
        if(hit.Length != 0)
        {
            foreach(RaycastHit2D hits in hit)
            {
                if(hits.collider != null && hits.collider.gameObject.CompareTag("monster"))
                {
                    foreach (int id in idEnemy)
                    {
                        if (id == hits.collider.gameObject.GetInstanceID()) return;
                    }
                    hits.collider.GetComponent<controllerHealthMonster>().takeDamageAndDie_Monster(this.transform.parent.GetComponent<playerController>().DamagePlayer 
                        + Random.Range(0, 120) + 150f);
                    idEnemy.Add(hits.collider.gameObject.GetInstanceID());
                }
            }
        }
    }
    private void DeactiveThis()
    {
        this.transform.parent.GetComponent<playerController>().SpeedPlayer = speedPlayer;
        idEnemy.Clear();
        this.gameObject.SetActive(false);
    }
    // trigger skill
    public void triggerSkill()
    {
        speedPlayer = this.transform.parent.GetComponent<playerController>().SpeedPlayer;
        this.transform.parent.GetComponent<playerController>().SpeedPlayer = 0;
        this.gameObject.SetActive(true);
    }
    public void endTriggerSkill() => print("end!");
}
