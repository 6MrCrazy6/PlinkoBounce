using TMPro;
using UnityEngine;

public class MainMenuUIControll : MonoBehaviour
{
    private CoinsManager coinsManager;

    public TextMeshProUGUI moneyText;

    void Start()
    {
        coinsManager = FindObjectOfType<CoinsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = coinsManager.money.ToString();
    }
}
