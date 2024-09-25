using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject fireballPrefab;
    public GameObject fireballChargingPrefab;
    public float ChargeTimeMultiplier = 2f;

    Fireball fireballscript;
    GameObject fireball;
    GameObject chargedFireball;

    public float chargeUpTime;
    bool isCharging;

    // Update is called once per frame
    void Update()
    {
        if (isCharging)
        {
            chargeUpTime += Time.deltaTime * ChargeTimeMultiplier; // build up charge to increase launch force of fireball with multiplier to increase time
        }
    }

    public void ChargeFireball()
    {
        isCharging = true;
        chargedFireball = Instantiate(fireballChargingPrefab, transform.position, transform.rotation, transform); // Spawn Fireball Charge and floats in front of player
    }

    public void ShootFireball()
    {
        isCharging = false;

        fireball = Instantiate(fireballPrefab, transform.position, transform.rotation);// Spawn Fireball

        fireballscript = fireball.GetComponent<Fireball>();// Get Fireball script

        fireballscript.launchForce = chargeUpTime;
        fireballscript.CastFireball();

        chargeUpTime = 0f;
    }
}
