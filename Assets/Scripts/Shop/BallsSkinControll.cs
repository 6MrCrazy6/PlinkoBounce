using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BallsSkinControll : MonoBehaviour
{
    public int BallskinNum;
    public Button buyButton;
    public int price;

    public Image[] Ballskins;

    public TextMeshProUGUI buyTextButton;

    private CoinsManager coinsManager;


    private void Start()
    {
        coinsManager = FindObjectOfType<CoinsManager>();
    }

    void Update()
    {
        if (PlayerPrefs.GetInt(GetComponent<Image>().name + "buy") == 0)
        {
            buyTextButton.text = price.ToString();
        }
        else if (PlayerPrefs.GetInt(GetComponent<Image>().name + "buy") == 1)
        {
            buyTextButton.text = "EQUIP";
            if (PlayerPrefs.GetInt(GetComponent<Image>().name + "EQUIP") == 1)
            {
                buyTextButton.text = "EQUIPPED";
            }
            else if (PlayerPrefs.GetInt(GetComponent<Image>().name + "EQUIP") == 0)
            {
                buyTextButton.text = "EQUIP";
            }
        }
    }
    public void Buy()
    {
        if (PlayerPrefs.GetInt(GetComponent<Image>().name + "buy") == 0)
        {
            if (coinsManager.money >= price)
            {
                coinsManager.money -= price;
                PlayerPrefs.SetFloat("Coin", coinsManager.money);
                PlayerPrefs.Save();
                PlayerPrefs.SetInt(GetComponent<Image>().name + "buy", 1);
                PlayerPrefs.SetInt("BallskinNum", BallskinNum);

                foreach (Image img in Ballskins)
                {
                    if (GetComponent<Image>().name == img.name)
                    {
                        PlayerPrefs.SetInt(GetComponent<Image>().name + "EQUIP", 1);
                    }
                    else
                    {
                        PlayerPrefs.SetInt(img.name + "EQUIP", 0);
                    }
                }
            }
        }

        else if (PlayerPrefs.GetInt(GetComponent<Image>().name + "buy") == 1)
        {

            PlayerPrefs.SetInt(GetComponent<Image>().name + "EQUIP", 1);
            PlayerPrefs.SetInt("BallskinNum", BallskinNum);

            foreach (Image img in Ballskins)
            {
                if (GetComponent<Image>().name == img.name)
                {
                    PlayerPrefs.SetInt(GetComponent<Image>().name + "EQUIP", 1);
                }
                else
                {
                    PlayerPrefs.SetInt(img.name + "EQUIP", 0);
                }
            }
        }
    }
}
