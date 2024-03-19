using UnityEngine;

public class BallControll : MonoBehaviour
{
    private CoinsManager coinManager;

    private float Money;

    private void Start()
    {
        coinManager = FindObjectOfType<CoinsManager>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Portal"))
        {
            Destroy(this.gameObject);
        }

        if (collision.CompareTag("1"))
        {
            Money = coinManager.amount * 1f;
            coinManager.money += Money;
            PlayerPrefs.SetFloat("Coin", coinManager.money);
            PlayerPrefs.Save();
            Destroy(this.gameObject);
        }
        else if (collision.CompareTag("1.5"))
        {
            Money = coinManager.amount * 1.5f;
            coinManager.money += Money;
            PlayerPrefs.SetFloat("Coin", coinManager.money);
            PlayerPrefs.Save();
            Destroy(this.gameObject);
        }
        else if (collision.CompareTag("2"))
        {
            Money = coinManager.amount * 2f;
            coinManager.money += Money;
            PlayerPrefs.SetFloat("Coin", coinManager.money);
            PlayerPrefs.Save();
            Destroy(this.gameObject);
        }
    }
}

