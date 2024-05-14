using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllerBulletSkill3 : MonoBehaviour
{
    [SerializeField] private float TimeAttach;
    private float time;
    private bool isMonster = false;
    private Vector2 normal;
    private RaycastHit2D[] hits = new RaycastHit2D[2];
    private int distanceHitRight = 15;
    private int distanceHitLeft = 15;

    [SerializeField] private GameObject bullet;
    private List<GameObject> listBullet = new List<GameObject>();
    private void Start()
    {
        Destroy(this.gameObject, 10f);
        time = 0;
    }
    private void Update()
    {
        hits[0] = Physics2D.Raycast(this.transform.position, Vector2.right, distanceHitRight);
        hits[1] = Physics2D.Raycast(this.transform.position, Vector2.left, distanceHitLeft);
        checkMonster();
        if (!isMonster) return;
        time -= Time.deltaTime;
        if (time > 0) return;
        AttachUseBullet();
        time = TimeAttach;
    }
    private void AttachUseBullet()
    {
        if (listBullet.Count == 0)
        {
            GameObject gameObject = Instantiate(bullet, this.transform.GetChild(0).transform.position, Quaternion.identity);
            gameObject.GetComponent<bulletPlayerController>().normal = normal;
            listBullet.Add(gameObject);
        }
        else
        {
            foreach (GameObject obj in listBullet)
            {
                if (!obj.activeSelf)
                {
                    obj.SetActive(true);
                    obj.transform.position = this.transform.GetChild(0).transform.position;
                    obj.transform.rotation = this.transform.rotation;
                    obj.GetComponent<bulletPlayerController>().speed = obj.GetComponent<bulletPlayerController>().Speed;
                    obj.GetComponent<bulletPlayerController>().normal = normal;
                    return;
                }
            }
            GameObject game = Instantiate(bullet, this.transform.GetChild(0).transform.position, Quaternion.identity);
            game.GetComponent<bulletPlayerController>().normal = normal;
            listBullet.Add(game);
        }
    }
    private void checkMonster()
    {
        if (hits[0].collider != null && hits[0].collider.gameObject.CompareTag("monster"))
        {
            distanceHitLeft = 0;
            normal = (hits[0].collider.gameObject.transform.position - this.transform.GetChild(0).transform.position).normalized;
            isMonster = true;
        }
        else if (hits[1].collider != null && hits[1].collider.gameObject.CompareTag("monster"))
        {
            normal = (hits[1].collider.gameObject.transform.position - this.transform.GetChild(0).transform.position).normalized;
            distanceHitRight = 0;
            isMonster = true;
        }
        else
        {
            print("thien");
            distanceHitLeft = 15;
            distanceHitRight = 15;
            isMonster = false;
        }
    }
}
