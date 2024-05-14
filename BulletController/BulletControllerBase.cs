using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletCOntrollerBase : MonoBehaviour
{
    [HideInInspector] public float speed = 20f;
    [HideInInspector] public Animator animator;
    [HideInInspector] public bool isMoveBullet = true;
    [HideInInspector] public Vector2 normal;
    [SerializeField] private Rigidbody2D rb;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        animator = GetComponent<Animator>();
        StartCoroutine(diActiveAftertime());
    }

    // Update is called once per frame
    void Update()
    {
        MoveBullet();
    }
    private void MoveBullet()
    {
        if (isMoveBullet) rb.velocity = normal * speed;
    }
    private void EndBullet()
    {
        this.gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("IsBreak", true);
            isMoveBullet = false;
            collision.gameObject.GetComponent<HealthPlayerController>().addDamageForPlayer(100f);
        }
    }
    public IEnumerator diActiveAftertime()
    {
        yield return new WaitForSeconds(10f);
        EndBullet();
    }
}
