using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScriptFlippper : MonoBehaviour
{
    public GameObject FireballSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<PlayerMovement>().enabled = true;
        GetComponent<PlayerLookAtMouse>().enabled = false;
        FireballSpawnPoint.GetComponent<PlayerShoot>().enabled = false;
        GetComponent<PlayerDash>().enabled = true;
        GetComponent<PlayerAbilityStun>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<PlayerLookAtMouse>().enabled = true;
            FireballSpawnPoint.GetComponent<PlayerShoot>().enabled = true;
            GetComponent<PlayerDash>().enabled = false;
            GetComponent<PlayerAbilityStun>().enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            GetComponent<PlayerMovement>().enabled = true;
            GetComponent<PlayerLookAtMouse>().enabled = false;
            FireballSpawnPoint.GetComponent<PlayerShoot>().enabled = false;
            GetComponent<PlayerDash>().enabled = true;
            GetComponent<PlayerAbilityStun>().enabled = false;
        }
    }
}
