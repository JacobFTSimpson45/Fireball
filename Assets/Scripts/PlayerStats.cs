using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int objectsDestroyed;
    public int currentHealth;
    public int radius = 50;
    public float currentTime = 0;
    public UiManager uiManager;

    public void Update()
    {
        currentTime += Time.deltaTime;
        uiManager.UpdateTimer(currentTime);

        Health PlayerHP = gameObject.GetComponent<Health>();
        currentHealth = PlayerHP.health;
        uiManager.UpdateHealth(currentHealth);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider col in colliders)
        {
            if (col.tag == "Enemy")
            {
                Health enemyHealth = col.gameObject.GetComponent<Health>();
                if (enemyHealth.health <= 0)
                {
                    objectsDestroyed++;
                }
            }
        }

        uiManager.UpdateScore(objectsDestroyed);
    }
}
