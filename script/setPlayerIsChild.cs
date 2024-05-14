using Unity.VisualScripting;
using UnityEngine;

public class setPlayerIsChild : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float A;

    [Header("MoveX is True and MoveY is False")]
    [SerializeField] private bool isMoveX;
    private System.Action m_Move;
    private void Start()
    {
        if (isMoveX) m_Move = MoveX;
        else m_Move = MoveY;
    }
    private void Update()
    {
        m_Move.Invoke();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.GetContact(0).normal.x <= -1) collision.transform.SetParent(this.transform);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player")) collision.transform.SetParent(null);
    }
    private void MoveX()
    {
        var x = A * Mathf.Sin(speed * Time.time) * Time.deltaTime;
        this.transform.position += new Vector3(x, 0, 0);
    }
    private void MoveY()
    {
        var x = A * Mathf.Sin(speed * Time.time) * Time.deltaTime;
        this.transform.position += new Vector3(0, x, 0);
    }
}
