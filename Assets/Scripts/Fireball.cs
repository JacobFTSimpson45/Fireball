using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Rigidbody rb; // Get RigidBody Component.
    public float launchForce = 0f;
    public float radius = 1f;
    public float force = 200f;
    public int damage = 1;

    public void CastFireball()
    {
        //give a force to our Projectile;
        rb.velocity = transform.forward * launchForce;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider col in colliders)
        {
            Health hp = col.GetComponent<Health>();
            if (hp != null)
            {
                hp.health -= damage;
            }
        }

        Destroy(gameObject);
    }
}
