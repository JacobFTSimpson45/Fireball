using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScriptFlippper : MonoBehaviour
{
    public GameObject FireballSpawnPoint;

    public GameObject wizard;
    Animator animator;

    PlayerMovement playerMovement;
    PlayerLookAtMouse playerLookAtMouse;
    PlayerShoot playerShoot;
    PlayerDash playerDash;
    PlayerAbilityStun playerAbilityStun;

    // Start is called before the first frame update
    void Start()
    {
        animator = wizard.GetComponent<Animator>();

        playerMovement = GetComponent<PlayerMovement>();
        playerLookAtMouse = GetComponent<PlayerLookAtMouse>();
        playerShoot = FireballSpawnPoint.GetComponent<PlayerShoot>();
        playerDash = GetComponent<PlayerDash>();
        playerAbilityStun = GetComponent<PlayerAbilityStun>();

        playerMovement.enabled = true;
        playerLookAtMouse.enabled = false;
        playerDash.enabled = true;
        playerAbilityStun.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            playerShoot.ChargeFireball();

            animator.SetBool("isCharging", true);

            playerMovement.enabled = false;
            playerLookAtMouse.enabled = true;
            playerDash.enabled = false;
            playerAbilityStun.enabled = false;

        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            playerShoot.ShootFireball();

            animator.SetBool("isCharging", false);

            playerMovement.enabled = true;
            playerLookAtMouse.enabled = false;
            playerDash.enabled = true;
            playerAbilityStun.enabled = true;
        }
    }
}
