using System.Collections;
using UnityEngine;

public abstract class PlayerControllerBase : MonoBehaviour
{
    public enum PlayerState { Idle, Run, Attach, Die }
    public abstract void SetPlayer();
    public void Move(Rigidbody2D rigibody, float speed) => rigibody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rigibody.velocity.y); 
    public void Flip(Rigidbody2D rigidbody, GameObject Object)
    {
        if (rigidbody.velocity.x > 0) Object.transform.localScale = new Vector3(Mathf.Abs(Object.transform.localScale.x), Object.transform.localScale.y, Object.transform.localScale.z);
        else if (rigidbody.velocity.x < 0) Object.transform.localScale = new Vector3(-1 * Mathf.Abs(Object.transform.localScale.x), Object.transform.localScale.y, Object.transform.localScale.z);
    }
    public void Jump(Rigidbody2D rigibody, float height, RaycastHit2D hit, GameObject Object, string tag)
    {
        hit = Physics2D.Raycast(Object.transform.position, Vector2.down, 1.65f, Physics2D.AllLayers);
        Debug.DrawRay(Object.transform.position, Vector2.down * 1.65f, Color.black);
        if(hit.collider != null && hit.collider.gameObject.CompareTag(tag) && Input.GetKeyDown(KeyCode.W))
        {
            rigibody.AddForce(Vector2.up * height, ForceMode2D.Impulse);
        }
    }
    public void Attach(ref PlayerState state, float timeAttach, ref bool isAttach, ref bool isStop, System.Action action)
    {
        if (isAttach && Input.GetKeyDown(KeyCode.F))
        {
            state = PlayerState.Attach;
            isAttach = false;
            isStop = true;
            StartCoroutine(AttachAfterTime(action, timeAttach));
        }
    }
    public void StopPlayer(Rigidbody2D rigidbody, bool isStop)
    {
        if (isStop) rigidbody.velocity = new Vector2(0f, rigidbody.velocity.y); 
    }
    private IEnumerator AttachAfterTime(System.Action action, float timeAttach)
    {
        yield return new WaitForSeconds(timeAttach);
        action?.Invoke();
    }
}
