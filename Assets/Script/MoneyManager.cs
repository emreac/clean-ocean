using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class MoneyManager : MonoBehaviour
{
    public TextMeshProUGUI moneyText; // Reference to the UI Text component
    private int money = 0; // Current money value

    void Start()
    {
        UpdateMoneyUI();
    }

    // Method to add money
    public void AddMoney(int amount)
    {
        money += amount;
        DOTween.Restart("moneyDrop");
        UpdateMoneyUI();
    }

    public void ReduceMoney(int amount)
    {
        money -= amount;
        UpdateMoneyUI();
    }

    // Method to update the UI Text with the current money value
    void UpdateMoneyUI()
    {
        moneyText.text = money.ToString();
    }
}
