using UnityEngine;

[CreateAssetMenu(fileName = "DataGoblin", menuName = "Data/Monster", order = 1)]
public class DataMonster : ScriptableObject
{
    public float Spped;
    public float Health;
    public float Damage;
    public float Gold;
    public float Exe;
    public Sprite Image;
}
