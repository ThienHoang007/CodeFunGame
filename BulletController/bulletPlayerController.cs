using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletPlayerController : MonoBehaviour
{
    [HideInInspector] public Vector2 normal;
    [HideInInspector] public float speed;
    public float Speed;
    private Rigidbody2D rigibody;
    private Animator clip;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroyAfterTime());
        clip = GetComponent<Animator>();
        rigibody = GetComponent<Rigidbody2D>();
        player = GameObject.Find("player");
        speed = Speed;
    }
    void OnEnable()
    {
        StartCoroutine(destroyAfterTime());
    }
    // Update is called once per frame
    void Update()
    {
        rigibody.velocity = speed * normal;
        if (rigibody.velocity.x > 0) this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        else if (rigibody.velocity.x < 0) this.transform.localScale = new Vector3(-Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("monster")) return;
        speed = 0;
        clip.SetBool("Attach", false);
        clip.SetBool("Break", true);
        collision.gameObject.GetComponent<controllerHealthMonster>().takeDamageAndDie_Monster(player.GetComponent<playerController>().DamagePlayer + Random.Range(100, 200));
    }
    private void destroyThis()
    {
        StopCoroutine(destroyAfterTime());
        this.gameObject.SetActive(false);
    }
    private IEnumerator destroyAfterTime()
    {
        yield return new WaitForSeconds(4f);
        this.gameObject.SetActive(false);
    }
}
