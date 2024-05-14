using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class buleltPlayer : MonoBehaviour
{
    [SerializeField] private Skill4StevePlayer skill4;
    [Header("dataBullet")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject bulletSkill4;
    private List<GameObject> listBullet = new List<GameObject>();
    private List<GameObject> listBulletSkill4 = new List<GameObject>(); 
    public void AttachUseBullet()
    {
        if(getListBullet().Count == 0)
        {
            GameObject gameObject = Instantiate(getdataBullet(), this.transform.position, Quaternion.identity);
            gameObject.GetComponent<bulletPlayerController>().normal = this.transform.parent.localScale.x > 0 ? new Vector2(1, 0) : new Vector2(-1, 0);
            getListBullet().Add(gameObject);
        }
        else
        {
            foreach(GameObject obj in getListBullet())
            {
                if(!obj.activeSelf)
                {
                    obj.SetActive(true);
                    obj.transform.position = this.transform.position;
                    obj.transform.rotation = this.transform.rotation;
                    obj.GetComponent<bulletPlayerController>().speed = obj.GetComponent<bulletPlayerController>().Speed;
                    obj.GetComponent<bulletPlayerController>().normal = this.transform.parent.localScale.x > 0 ? new Vector2(1, 0) : new Vector2(-1, 0);
                    return;
                }
            }
            GameObject game = Instantiate(getdataBullet(),this.transform.position,Quaternion.identity);
            game.GetComponent<bulletPlayerController>().normal = this.transform.parent.localScale.x > 0 ? new Vector2(1, 0) : new Vector2(-1, 0);
            getListBullet().Add(game);
        }
    }
    private GameObject getdataBullet()
    {
        if (skill4.triggerSkill4) return bulletSkill4;
        else return bullet;
    }
    private List<GameObject> getListBullet()
    {
        if (skill4.triggerSkill4) return listBulletSkill4;
        else return listBullet;
    }
}
