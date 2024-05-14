using UnityEngine;

[CreateAssetMenu(fileName = "DatePlayer", menuName = "Data/Player", order = 1)]
public class DataPlayer : ScriptableObject
{
    public float Speed;
    public float Hieght;
    public float Damage;
    public float Health;
    public float AttachSppedUp;
    public bool AttachRange;
    public Sprite Image;
}
