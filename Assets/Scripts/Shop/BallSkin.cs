using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallSkin : MonoBehaviour
{
    public Sprite standart;
    public Sprite skin1;
    public Sprite skin2;
    public Sprite skin3;
    public Sprite skin4;
    public Sprite skin5;
    public Sprite skin6;
    public Sprite skin7;

    public GameObject Ball;

    void Start()
    {
        if (PlayerPrefs.GetInt("BallskinNum") == 1)
        {
            Ball.GetComponent<Image>().sprite = skin1;
        }
        else if (PlayerPrefs.GetInt("BallskinNum") == 2)
        {
            Ball.GetComponent<Image>().sprite = skin2;
        }
        else if (PlayerPrefs.GetInt("BallskinNum") == 3)
        {
            Ball.GetComponent<Image>().sprite = skin3;
        }
        else if (PlayerPrefs.GetInt("BallskinNum") == 4)
        {
            Ball.GetComponent<Image>().sprite = skin4;
        }
        else if (PlayerPrefs.GetInt("BallskinNum") == 5)
        {
            Ball.GetComponent<Image>().sprite = skin5;
        }
        else if (PlayerPrefs.GetInt("BallskinNum") == 6)
        {
            Ball.GetComponent<Image>().sprite = skin6;
        }
        else if (PlayerPrefs.GetInt("BallskinNum") == 7)
        {
            Ball.GetComponent<Image>().sprite = skin7;
        }

        else
        {
            Ball.GetComponent<Image>().sprite = standart;
        }

    }
}
