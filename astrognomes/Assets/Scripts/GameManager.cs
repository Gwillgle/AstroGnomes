using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public double money;

    [Header("Gnomes Owned")]
    public int clickValue = 1;
    public int clickLevel = 1;
    public int clickCost = 10;

    [Header("Auto Upgrade")]
    public int autoIncome = 0;
    public int autoOwned = 0;
    public int autoCost = 50;

    [Header("Lucky Upgrade")]
    public float luckyChance = 0.10f;
    public int luckyBonus = 10;
    public int luckyLevel = 1;
    public int luckyCost = 100;

    [Header("UI")]
    public TMP_Text moneyText;
    public TMP_Text betterCursorText;
    public TMP_Text autoText;
    public TMP_Text luckyText;

    void Update()
    {
        money += autoIncome * Time.deltaTime;
        UpdateUI();
    }

    void UpdateUI()
    {
        moneyText.text = money.ToString("F0") + " Coins";

        betterCursorText.text =
            "Better Cursor\nLevel: " + clickLevel +
            "\nCost: " + clickCost;

        autoText.text =
            "Auto Collector\nOwned: " + autoOwned +
            "\nCost: " + autoCost;

        luckyText.text =
            "Lucky Click\nChance: " + (luckyChance * 100).ToString("F0") + "%" +
            "\nCost: " + luckyCost;
    }

    public void Click()
    {
        money += clickValue;

        if (Random.value < luckyChance)
        {
            money += luckyBonus;
        }
    }

    public void BuyBetterCursor()
    {
        if (money >= clickCost)
        {
            money -= clickCost;
            clickLevel++;
            clickValue++;
            clickCost *= 2;
        }
    }

    public void BuyAutoCollector()
    {
        if (money >= autoCost)
        {
            money -= autoCost;
            autoOwned++;
            autoIncome++;
            autoCost *= 2;
        }
    }

    public void BuyLuckyClick()
    {
        if (money >= luckyCost)
        {
            money -= luckyCost;
            luckyLevel++;
            luckyChance += 0.05f;
            luckyBonus += 10;
            luckyCost *= 2;
        }
    }
}