using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    [SerializeField] private Image fuelBarImage;
    [SerializeField, Range(0.1f, 5f)] private float fuelDrainSpeed = 1f;
    [SerializeField] private float maxFuelAmount = 100f;
    [SerializeField] private Gradient fuelBarGradient;

    private float currentFuelAmount;

    [SerializeField] private GameObject gameOverCanvas;


    private int currentCoins;

    [SerializeField] private TextMeshProUGUI coinsCollected;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        Time.timeScale = 1f;
    }


    private void Start()
    {
        PlayerPrefs.DeleteAll();

        currentFuelAmount = maxFuelAmount;

        UpdateUI();
    }


    private void Update()
    {
        DrainFuel();
        UpdateUI();

        if(CheckIfFuelIsEmpty())
        {
            GameOver();
        }
    }


    private void UpdateUI()
    {
        fuelBarImage.fillAmount = (currentFuelAmount / maxFuelAmount);
        fuelBarImage.color = fuelBarGradient.Evaluate(fuelBarImage.fillAmount);
    }


    private void DrainFuel()
    {
        currentFuelAmount -= fuelDrainSpeed * Time.deltaTime;
    }


    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    private bool CheckIfFuelIsEmpty()
    {
        if(currentFuelAmount <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public void FuelCollected()
    {
        currentFuelAmount = maxFuelAmount;

        UpdateUI();
    }


    public void UpdateScore(int newScore)
    {
        currentCoins = newScore;

        coinsCollected.text = currentCoins.ToString();
    }

    public int GetScore()
    {
        return currentCoins;
    }
}










