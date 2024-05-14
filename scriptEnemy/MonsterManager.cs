using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    private static MonsterManager instance = null;
    public static MonsterManager Instance => instance;

    public int valueMonster = 0;
    private void Awake()
    {
        if (instance == null) instance = this;
        else if (this.GetInstanceID() != instance.GetInstanceID()) Destroy(this);
    }
    private void Update()
    {
        print(valueMonster);
    }
    public IEnumerator diactivePitAfterTime()
    {
        yield return new WaitUntil(() => valueMonster == 0);
    }
}
