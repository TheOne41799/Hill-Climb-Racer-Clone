using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { get; private set; }
    private int totalCoins;

    private void Awake()
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

    private void Start()
    {
        totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);

        GameManager.Instance.UpdateScore(totalCoins);
    }

    public void AddCoins(int amount)
    {
        totalCoins += amount;
        GameManager.Instance.UpdateScore(totalCoins);

        PlayerPrefs.SetInt("TotalCoins", totalCoins);
    }

    public int GetTotalCoins()
    {
        return totalCoins;
    }
}
