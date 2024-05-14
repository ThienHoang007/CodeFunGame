using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MonsterController : MonsterBase
{
    [Header("ValueMonster")]
    [SerializeField] DataMonster data;
    private float speed;
    private float damage;
    private float glod;
    private float exp;

    [HideInInspector] public float damageMonster;
    [HideInInspector] public float speedMonster;
    [HideInInspector] public float expMonster;
    [HideInInspector] public float glodMonster;

    private Rigidbody2D rigibody;
    private GameObject player;
    private RaycastHit2D[] hits;
    private Vector2 normal;

    private float TimeAttach;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        SetDataStartMonster(data);
        setValueMonster();
        rigibody = GetComponent<Rigidbody2D>();
        TimeAttach = 2.5f;
    }

    // Update is called once per frame
    void Update()
    {
        normal = (this.transform.position - player.transform.position).normalized;
        Move(rigibody,speedMonster, normal);
        FLip(rigibody, this.gameObject);
        Stop(rigibody, this.gameObject, player, 2.3f, checkStateMonster);
    }
    private void setValueMonster()
    {
        speedMonster = speed;
        damageMonster = damage;
        glodMonster = glod;
        expMonster = exp;
    }
    public override void SetDataStartMonster(DataMonster Data)
    {
        this.speed = Data.Spped;
        this.damage = Data.Damage;
        this.glod = Data.Gold;
        this.exp = Data.Exe;
    }
    private void checkStateMonster()
    {
        hits = Physics2D.RaycastAll(this.transform.position, new Vector2(this.transform.localScale.x, -0.4f), 2.5f);
        if(hits.Length != 0)
        {
            foreach (var hit in hits)
            {
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    TimeAttach -= Time.deltaTime;
                    if (TimeAttach > 0) return;
                    this.GetComponent<AnimationMonster>().stateMonster = AnimationMonster.MonsterState.Attach;
                    TimeAttach = 2.5f;
                }
            }
        }
    }
    public void StartSpeed()
    {
        StopCoroutine(SpeedUpAfterTime());
        StartCoroutine(SpeedUpAfterTime());
    }
    private IEnumerator SpeedUpAfterTime()
    {
        yield return new WaitForSeconds(3.5f);
        speedMonster = speed;
    }
}
