using System;
using System.Collections;
using UnityEngine;

public abstract class MonsterBase : MonoBehaviour
{
    public abstract void SetDataStartMonster(DataMonster Data);
    public void Move(Rigidbody2D rigibody, float speed, Vector2 normal)
    {
        if (normal.x > 0) rigibody.velocity = new Vector2(-speed, rigibody.velocity.y);
        else if (normal.x < 0) rigibody.velocity = new Vector2(speed, rigibody.velocity.y); 
    }
    public void FLip(Rigidbody2D rigibody, GameObject Object)
    {
        if (rigibody.velocity.x > 0) Object.transform.localScale = new Vector3(Mathf.Abs(Object.transform.localScale.x), Object.transform.localScale.y, Object.transform.localScale.z);
        else if (rigibody.velocity.x < 0) Object.transform.localScale = new Vector3(-Mathf.Abs(Object.transform.localScale.x), Object.transform.localScale.y, Object.transform.localScale.z);
    }
    public void Stop(Rigidbody2D rigidbody, GameObject Object, GameObject player, float distance, Action action)
    {
        if(Mathf.Abs(Object.transform.position.x - player.transform.position.x) < distance)
        {
            rigidbody.velocity = new Vector2(0f, rigidbody.velocity.y);
            action?.Invoke();
        }
    }
}
