using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class UiManager : MonoBehaviour
{
    [SerializeField] GameObject deathPanel;
    [SerializeField] GameObject player;
    public TextMeshProUGUI timerUIText;
    public TextMeshProUGUI scoreUIText;
    public TextMeshProUGUI healthUIText;

    private void Start()
    {
        deathPanel.SetActive(false);
    }
    void Update()
    {
       Health playerHP = player.GetComponent<Health>();
        if (playerHP.health <= 0)
        {
            deathPanel.SetActive(true);
            gameObject.SetActive(false);
        }
    }

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
