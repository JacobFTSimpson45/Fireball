using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityStun : MonoBehaviour
{
    public float radius = 1f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            DetectEnemy();
        }
    }
    private void DetectEnemy()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider col in colliders)
        {
            if (col.tag == "Enemy")
            {
                col.gameObject.GetComponent<EnemyAI>().GetStunned();
            }
        }
    }
}
