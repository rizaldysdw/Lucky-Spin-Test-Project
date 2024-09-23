using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private Text _coinText;
    [SerializeField] private Text _diamondText;
    [SerializeField] private TextMeshProUGUI _infoText;

    void Start()
    {
        AssignUI();

        if (_coinText) GameManager.Instance.UpdateCoinText(_coinText);
        if (_diamondText) GameManager.Instance.UpdateDiamondText(_diamondText);
    }

    private void AssignUI()
    {
        _coinText = GameObject.Find("CoinText").GetComponent<Text>();
        _diamondText = GameObject.Find("DiamondText").GetComponent<Text>();
        _infoText = GameObject.Find("InfoText").GetComponent<TextMeshProUGUI>();
    }

    public void BuyWithCoin(int coinRequired)
    {
        if (GameManager.Instance.CoinAmount >= coinRequired)
        {
            GameManager.Instance.CoinAmount -= coinRequired;
            GameManager.Instance.UpdateCoinText(_coinText);

            LoadLuckySpinScene();
        }
        else
        {
            UpdateWarningText("Coin");
        }
    }

    public void BuyWithDiamond(int diamondRequired)
    {
        if (GameManager.Instance.DiamondAmount >= diamondRequired)
        {
            GameManager.Instance.DiamondAmount -= diamondRequired;
            GameManager.Instance.UpdateDiamondText(_diamondText);

            LoadLuckySpinScene();
        }
        else
        {
            UpdateWarningText("Diamond");
        }
    }

    public void BuyCharacter(string rarity)
    {
        GameManager.Instance.selectedRarity = rarity;
    }

    public void UpdateWarningText(string currencyText)
    {
        if (_infoText == null) return;

        _infoText.text = $"{currencyText} is not enough to buy a new character!";
    }

    public void LoadLuckySpinScene()
    {
        SceneManager.LoadScene("LuckySpin");
    }
}
