using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAbilityStun : MonoBehaviour
{
    public float radius = 1f;

    public GameObject wizard;
    Animator animator;

    public GameObject decalProjector;

    private void Start()
    {
        animator = wizard.GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            DetectEnemy();
            animator.SetBool("isStunning", true);
            decalProjector.gameObject.SetActive(true);
        }
        else
        {
            animator.SetBool("isStunning", false);
            decalProjector.gameObject.SetActive(false);
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
