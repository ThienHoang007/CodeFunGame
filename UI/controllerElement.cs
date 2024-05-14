using UnityEngine.UI;
using UnityEngine;

public class controllerElement : MonoBehaviour
{
    public int idCharacter;
    public float price;
    public controllerGoldUiShop money;
    public Button btnPrice;
    public Text txtPrice;
    public void Awake()
    {
        setTextPrice(this.idCharacter);
    }
    public void setTextPrice(int idCharacter)
    {
        if(idCharacter == PlayerPrefs.GetInt(StringData.idCharacter))
        {
            txtPrice.text = "Dang Sử Dụng";
            btnPrice.onClick.AddListener(() => print("using"));
        }
        else
        {
            if (GameManager.Instance.isCharacter_Player(idCharacter))
            {
                txtPrice.text = "Sử Dụng";
                btnPrice.onClick.AddListener(useCharacter);
            }
            else
            {
                txtPrice.text = price.ToString();
                btnPrice.onClick.AddListener(buyCharacter);
            }
        }
    }
    public void useCharacter()
    {
        PlayerPrefs.SetInt(StringData.idCharacter, idCharacter);
        Observer.Instance.Notify(StringData.UpdatTextShop);
    }
    public void buyCharacter()
    {
        GameManager.Instance.SaveIdCharacter(idCharacter);
        money.deduction(price, true);
        Observer.Instance.Notify(StringData.UpdatTextShop);
    }
}
