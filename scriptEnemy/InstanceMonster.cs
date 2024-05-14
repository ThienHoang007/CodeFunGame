using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceMonster : MonoBehaviour
{
    [SerializeField] private GameObject Goblin;
    [SerializeField] private GameObject Skeleton;
    [SerializeField] private GameObject FlyEye;
    private List<GameObject> Goblins = new List<GameObject>();
    private List<GameObject> Skeletons = new List<GameObject>();
    private List<GameObject> FlyEyes = new List<GameObject>();
    private int i = 0;
    [SerializeField] private Animator animator;

    private void InstanceEnemy(int id)
    {
        if (getListWithId(id).Count == 0)
        {
            var game = Instantiate(getMonsterWithId(id),this.transform.position + new Vector3(2 * this.transform.localScale.x,0,0), Quaternion.identity);
            getListWithId(id).Add(game);
        }
        else
        {
            foreach (var g in getListWithId(id))
            {
                if (!g.activeSelf)
                {
                    g.SetActive(true);
                    g.transform.position = this.transform.position + new Vector3(2 * this.transform.localScale.x, 0, 0);
                    g.transform.rotation = this.transform.rotation;
                    return;
                }
            }
            var game = Instantiate(getMonsterWithId(id), this.transform.position + new Vector3(2 * this.transform.localScale.x, 0, 0), Quaternion.identity);
            getListWithId(id).Add(game);
        }
        i++;
    }
    private List<GameObject> getListWithId(int id)
    {
        switch (id)
        {
            case 0:
                return Goblins;
            case 1:
                return Skeletons;
            case 2: 
                return FlyEyes;
            default: return null;
        }
    }
    private GameObject getMonsterWithId(int id)
    {
        switch (id)
        {
            case 0:
                return Goblin;
            case 1:
                return Skeleton;
            case 2:
                return FlyEye;
            default: return null;
        }
    }
    public IEnumerator InstacneMonsterAfterTime(int id, float quantity, float time)
    {
        yield return new WaitForSeconds(time);
        InstanceEnemy(id);
        if (i >= quantity)
        {
            i = 0;
            yield break;
        }
        StartCoroutine(InstacneMonsterAfterTime(id, quantity, time));
    }
    public IEnumerator diactivePit()
    {
        yield return new WaitUntil(() => MonsterManager.Instance.valueMonster == 0);
        setAnimationEnd();
    }
    public void setAnimatorRuning() => animator.SetBool("Runing", true);
    private void setAnimationEnd()
    {
        animator.SetBool("End", true);
        animator.SetBool("Runing", false);
    }
    public void destroyPit() => Destroy(this.gameObject);
}
