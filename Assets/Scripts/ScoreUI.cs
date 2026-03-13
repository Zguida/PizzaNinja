using System;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    private int _score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private string numberOfCoins;
    
    private void Start()
    {
        scoreText.text = "Coins Collected: " + _score.ToString() + "/" + numberOfCoins;
    }

    public void IncreaseScore()
    {
        _score++;
        scoreText.text = "Coins Collected: " + _score.ToString() + "/" + numberOfCoins;
    }
}
