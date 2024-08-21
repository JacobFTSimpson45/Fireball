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

    public float ChargeUpTime;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0)) 
        {
            chargedFireball = Instantiate(fireballChargingPrefab, transform.position, transform.rotation, transform); // Spawn Fireball Charge and floats in front of player
            ChargeUpTime += Time.deltaTime * ChargeTimeMultiplier; // build up charge to increase launch force of fireball with multiplier to increase time
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            fireball = Instantiate(fireballPrefab, transform.position, transform.rotation);// Spawn Fireball

            fireballscript = fireball.GetComponent<Fireball>();// Get Fireball script

            fireballscript.launchForce = ChargeUpTime;
            fireballscript.CastFireball();

            ChargeUpTime = 0f;
        }

    }
}
