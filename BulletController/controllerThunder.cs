using UnityEngine;

public class controllerThunder : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boxCollider2D;
    private Collider2D[] Collider2D;
    private MonsterController monsterController;
    private void addFroceForMonster()
    {
        Collider2D = Physics2D.OverlapBoxAll(this.transform.position + new Vector3(0,boxCollider2D.bounds.size.y / 2,0), boxCollider2D.bounds.size, 0);
        if(Collider2D.Length != 0)
        {
            foreach(Collider2D collider2Ds in Collider2D)
            {
                if (collider2Ds.gameObject.CompareTag("monster"))
                {
                    if (!collider2Ds.TryGetComponent<MonsterController>(out monsterController))
                    {
                        collider2Ds.GetComponent<controllerHealthMonster>().takeDamageAndDie_Monster(1000f);
                        continue;
                    }
                    monsterController.speedMonster = 0.7f;
                    monsterController.speedMonster = 0.4f;
                    monsterController.StartSpeed();
                    collider2Ds.GetComponent<controllerHealthMonster>().takeDamageAndDie_Monster(1000f);
                }
            }
        }
    }
    private void destroyThis() => this.gameObject.SetActive(false);
}
