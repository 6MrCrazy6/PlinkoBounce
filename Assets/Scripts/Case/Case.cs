using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Case : MonoBehaviour
{
    public Button keyButton;

    public TextMeshProUGUI keyButtonText;
    public TextMeshProUGUI moneyText;

    private CoinsManager coinsManager;

    private bool isButtonCooldown = false;
    private DateTime nextCaseTime;

    private void Start()
    {
        coinsManager = FindObjectOfType<CoinsManager>();
        LoadNextTime();
    }


    public void OpenKeys()
    {
        if (isButtonCooldown)
        {
            return;
        }

        int earnedCoins = UnityEngine.Random.Range(100, 1001);
        coinsManager.money += earnedCoins;
        PlayerPrefs.SetFloat("Coin", coinsManager.money);
        PlayerPrefs.Save();

        moneyText.text = coinsManager.money.ToString();

        isButtonCooldown = true;
        keyButton.interactable = false;
        nextCaseTime = DateTime.Now.AddMinutes(30); 
        
        SaveNextTime();
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator ButtonCooldown()
    {
        yield return new WaitForSeconds(1f);
        isButtonCooldown = false;
        keyButton.interactable = true;
        keyButtonText.text = "OPEN";
        keyButtonText.fontSize = 80;
        yield break;
    }

    private IEnumerator UpdateTimer()
    {
        TimeSpan remainingTime = nextCaseTime - DateTime.Now;
        if (remainingTime.TotalSeconds > 0)
        {
            string timeString = string.Format("{0:00}:{1:00}:{2:00}", remainingTime.Hours, remainingTime.Minutes, remainingTime.Seconds);
            keyButtonText.text = timeString;
            keyButtonText.fontSize = 45;
            keyButton.interactable = false;
            yield return new WaitForSeconds(1f);
            yield return StartCoroutine(UpdateTimer());
        }
        else
        {
            yield return StartCoroutine(ButtonCooldown());
        }
    }
    private void SaveNextTime()
    {
        PlayerPrefs.SetString("NextTime", nextCaseTime.ToString());
        PlayerPrefs.Save();
    }

    private void LoadNextTime()
    {
        if (PlayerPrefs.HasKey("NextTime"))
        {
            string nextTimeString = PlayerPrefs.GetString("NextTime");
            nextCaseTime = DateTime.Parse(nextTimeString);
            StartCoroutine(UpdateTimer());
            isButtonCooldown = true;
            keyButton.interactable = false;
        }
        else
        {
            isButtonCooldown = false;
            keyButton.interactable = true;
        }
    }
}
