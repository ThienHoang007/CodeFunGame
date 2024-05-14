using UnityEngine.UI;
using UnityEngine;
using UnityEngine.TextCore.Text;
using System.Collections.Generic;

public class controllerMainShop : MonoBehaviour
{
    public List<GameObject> shops = new List<GameObject>();
    private void Awake()
    {
        Observer.Instance.AddListaner(StringData.UpdatTextShop, UpdateShop_Text);
    }
    public void UpdateShop_Text()
    {
        foreach (GameObject go in shops)
        {
            go.GetComponent<controllerElement>().setTextPrice(go.GetComponent<controllerElement>().idCharacter);
        }
    }
}
