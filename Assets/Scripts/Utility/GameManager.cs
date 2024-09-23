using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int CoinAmount = 5000;
    public int DiamondAmount = 500;

    public string selectedRarity;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }    
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateCoinText(Text coinText)
    {
        if (coinText == null) return;

        coinText.text = GameManager.Instance.CoinAmount.ToString();
    }

    public void UpdateDiamondText(Text diamondText)
    {
        if (diamondText == null) return;
        diamondText.text = GameManager.Instance.DiamondAmount.ToString();
    }
}
