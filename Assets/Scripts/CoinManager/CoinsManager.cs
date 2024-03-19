using TMPro;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    public TextMeshProUGUI moneyText;

    public float money;
    public float amount = 50;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Coin"))
            money = 2000;
        else
            money = PlayerPrefs.GetFloat("Coin");

        //PlayerPrefs.DeleteAll();

        UpdateMoneyText();
    }

    private void Update()
    {
        UpdateMoneyText();
    }

    public void AddMoney(float amountToAdd)
    {
        money += amountToAdd;
        UpdateMoneyText();
    }

    public void UpdateMoneyText()
    {
        if (moneyText != null)
            moneyText.text = money + " / " + amount.ToString();
    }

}
