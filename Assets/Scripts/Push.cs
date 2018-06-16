using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : Skill
{
    public float radius = 5.0F;
    public float power = 10.0F;


    protected override void ActiveSkill()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

        InstantiateParticles();
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null && rb.gameObject.tag != "Player")
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
        }
    }
}
