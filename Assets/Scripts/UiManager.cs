using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI timerUIText;
    public TextMeshProUGUI scoreUIText;
    public TextMeshProUGUI healthUIText;

    public void UpdateTimer(float timerAmount)
    {
        int timeAmount = Convert.ToInt32(timerAmount);
        timerUIText.text = timeAmount.ToString();
    }
    public void UpdateScore(int scoreAmount)
    {
        scoreUIText.text = "Score : " + scoreAmount.ToString();
    }
    public void UpdateHealth(int healthAmount)
    {
        healthUIText.text = "Health : " + healthAmount.ToString();
    }
}
