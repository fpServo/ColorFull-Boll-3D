using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UiManager UIManager;
    public AdManager ADManager;
    public AdRewarded ADRewarded;

    private void Start()
    {
        CoinCalculator(0);
        Debug.Log(PlayerPrefs.GetInt("Money"));

         
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("FinisLine"))
        {
            Debug.Log("Oyun bitti");
            ADManager.RequestInterstitialAd();
            ADRewarded.LoadRewardedAd();
            CoinCalculator(100);
            UIManager.CoinTextUpdate();
            UIManager.FinishScreeen();
            PlayerPrefs.SetInt("LevelIndex", PlayerPrefs.GetInt("LevelIndex") + 1);
        }
    }

    public void CoinCalculator(int money)
    {
        if (PlayerPrefs.HasKey("Money"))
        {
            int oldScore = PlayerPrefs.GetInt("Money");
            PlayerPrefs.SetInt("Money", oldScore + money);
        }
        else
        {
            PlayerPrefs.SetInt("Money", 0);
        }
    }
}
