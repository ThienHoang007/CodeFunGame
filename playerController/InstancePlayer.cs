using System.Collections.Generic;
using UnityEngine;

public class InstancePlayer : MonoBehaviour
{
    [SerializeField] private List<GameObject> player = new List<GameObject>();
    private void Awake()
    {
        switch (PlayerPrefs.GetInt(StringData.idCharacter))
        {
            case 1:
                Instantiate(player[0], this.transform.position, Quaternion.identity).name = "player";
                break;
            case 2:
                Instantiate(player[1], this.transform.position, Quaternion.identity).name = "player";
                break;
            default:
                Debug.LogError("don't have player");
                break;
        }
    }
}
