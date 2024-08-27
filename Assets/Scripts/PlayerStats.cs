using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int objectsHit;
    public int currentHealth;
    public float currentTime = 60;
    public UiManager uiManager;

    public void Update()
    {
        currentTime -= Time.deltaTime;
        uiManager.UpdateTimer(currentTime);


        uiManager.UpdateScore(objectsHit);

        Health hp = gameObject.GetComponent<Health>();
        currentHealth = hp.health;
        uiManager.UpdateHealth(currentHealth);
    }
}
