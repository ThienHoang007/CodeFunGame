using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlyMonsterController : MonoBehaviour
{
    [SerializeField] private DataMonster DataFly;
    [Header("DataMonster")]
    public float SpeedFly = 1.75f;
    //private float DamageFly = 50;
    private float HealthFly = 30;

   [SerializeField] private float distanceMonsterAndPlayer = 27f;
    private GameObject player;
    private Rigidbody2D rigibody;
    private AnimationMonster State;

    private Vector2 normal;
    private RaycastHit2D[] hit;
    private bool isAttach = true;

    [SerializeField] private GameObject bullet;
    private List<GameObject> bullets = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        rigibody = GetComponent<Rigidbody2D>();
        State = this.GetComponent<AnimationMonster>();  
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(this.transform.position, new Vector2(this.transform.localScale.x, 0f) * 50f, Color.red);
        normal = ((Vector2)(this.transform.position - player.transform.position)).normalized;
        FlyMonsterAccorPlayer(distanceMonsterAndPlayer);
    }
    private void FlyMonsterAccorPlayer(float Distance)
    {
        if (Mathf.Abs(this.transform.position.x - player.transform.position.x) > Distance && Mathf.Abs(this.transform.position.x - player.transform.position.x) < Distance + 5)
        {
            if (normal.x < 0) this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
            else if (normal.x > 0) this.transform.localScale = new Vector3(-Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
            this.rigibody.velocity = new Vector2(0, 0);
            if (isAttach && checkPlayer())
            {
                StartCoroutine(AttachAfterTimeG());
                State.stateMonster = AnimationMonster.MonsterState.Attach;
                isAttach = false;
            }
        }
        else if(Mathf.Abs(this.transform.position.x - player.transform.position.x) < Distance)
        {
            if (normal.x < 0) rigibody.velocity = new Vector2(-SpeedFly, rigibody.velocity.y);
            else if (normal.x > 0) rigibody.velocity = new Vector2(SpeedFly, rigibody.velocity.y);
            FlipMonster();
        }
        else if(Mathf.Abs(this.transform.position.x - player.transform.position.x) > Distance + 2.5)
        {
            if (normal.x < 0) rigibody.velocity = new Vector2(SpeedFly, rigibody.velocity.y);
            else if (normal.x > 0) rigibody.velocity = new Vector2(-SpeedFly, rigibody.velocity.y);
            FlipMonster();
        }
    }
    public void FlipMonster()
    {
        if (rigibody.velocity.x > 0)
        {
            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
        else if (rigibody.velocity.x < 0)
        {
            this.transform.localScale = new Vector3(-Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
    }
    private void MonsterAttach()
    {
        StartCoroutine(AttachAfterTimeG());
        State.stateMonster = AnimationMonster.MonsterState.Attach;
        isAttach = false;
        if (bullets.Count == 0)
        {
            var g = Instantiate(bullet, (Vector2)(this.transform.position + new Vector3(getNormal() * 0.415f, -0.327f, 0f)), Quaternion.identity);
            g.GetComponent<BulletCOntrollerBase>().normal = normal.x < 0 ? new Vector2(1, 0) : new Vector2(-1, 0);
            bullets.Add(g);    
        }
        else
        {
            foreach(GameObject gameObject in bullets)
            {
                if(!gameObject.activeSelf)
                {
                    gameObject.SetActive(true);
                    gameObject.transform.position = this.transform.position + new Vector3(getNormal() * 0.415f, -0.327f, 0f);
                    gameObject.transform.rotation = Quaternion.identity;
                    var monster = gameObject.GetComponent<BulletCOntrollerBase>();
                    monster.isMoveBullet = true;
                    monster.animator.SetBool("IsBreak", false);
                    monster.normal = normal.x < 0 ? new Vector2(1, 0) : new Vector2(-1, 0);
                    monster.StartCoroutine(monster.diActiveAftertime());
                    return;
                }
            }
            var game = Instantiate(bullet, (Vector2)(this.transform.position + new Vector3(getNormal() * 0.415f, -0.327f, 0f)), Quaternion.identity);
            game.GetComponent<BulletCOntrollerBase>().normal = normal.x < 0 ? new Vector2(1, 0) : new Vector2(-1, 0);
            bullets.Add(game);
        }
    }
    private int getNormal()
    {
        if (normal.x < 0) return 1;
        else if (normal.x > 0) return -1;
        else return 0;
    }
    public void TakeDamageAndDie(float Damage = 0)
    {
        if (HealthFly >= 0)
        {
            State.stateMonster = AnimationMonster.MonsterState.TakeDamage;
            HealthFly -= Damage;
            UpdateText(Damage, this.transform.GetChild(0).GetComponentInChildren<Text>());
            UpdateSlider(HealthFly / 30, this.transform.GetChild(0).GetComponentInChildren<Slider>());
            this.transform.GetChild(0).GetComponentInChildren<ControllerAnimationText>().SetAnamiation();
            return;
        }
        SpeedFly = 0f;
        State.stateMonster = AnimationMonster.MonsterState.Die;
    }
    private void UpdateText(float value, Text text) => text.text = value.ToString();
    private void UpdateSlider(float value, Slider slider) => slider.value = value;
    private bool checkPlayer()
    {
        hit = Physics2D.RaycastAll(this.transform.position, new Vector2(this.transform.localScale.x, 0f), 50f, Physics2D.AllLayers);
        if(hit.Length != 0)
        {
            foreach(RaycastHit2D item in hit)
            {
                if (item.collider.gameObject.CompareTag("Player")) return true;
            }
        }
        return false;
    }
    private IEnumerator AttachAfterTimeG()
    {
        yield return new WaitForSeconds(4);
        isAttach = true;
    }
}
