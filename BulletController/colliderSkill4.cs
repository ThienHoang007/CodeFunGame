using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderSkillPlayer : MonoBehaviour
{
    [SerializeField] private GameObject game;
    private List<GameObject> games = new List<GameObject>();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("monster")) return;
        if (games.Count == 0)
        {
            GameObject g = Instantiate(game, collision.transform.position - new Vector3(Random.Range(-1,1),0,0), Quaternion.identity);
            games.Add(g);
        }
        else
        {
            foreach(GameObject game in games)
            {
                if(!game.activeSelf)
                {
                    game.SetActive(true);
                    game.transform.position = collision.transform.position - new Vector3(Random.Range(-1, 1), 0, 0);
                    game.transform.rotation = this.transform.rotation;
                    return;
                }
            }
            GameObject g = Instantiate(game, collision.transform.position - new Vector3(Random.Range(-1, 1),0,0), Quaternion.identity);
            games.Add(g);
        }
    }
}
