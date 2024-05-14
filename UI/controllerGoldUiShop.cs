using UnityEngine;

public class controllerGoldUiShop : MonoBehaviour
{
    public float money;
    public UnityEngine.UI.Text textMoney;
    public void deduction(float money, bool AddOrMinu)
    {
        if (AddOrMinu)
        {
            this.money -= money;
            updateMoney();
        }
        else
        {
            this.money -= money;
            updateMoney();
        }
    }
    private void updateMoney()
    {
        textMoney.text = money.ToString();
    }
}
