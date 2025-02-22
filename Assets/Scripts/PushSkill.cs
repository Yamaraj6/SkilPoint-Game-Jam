﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushSkill : Skill
{
    public float radius = 5.0F;
    public float power = 10.0F;

    override protected void Start()
    {
        base.Start();
        coolDown = GameObject.FindGameObjectWithTag("Push").GetComponent<CoolDown>();
    }

    protected override void ActiveSkill()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

        InstantiateParticles();
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null && rb.gameObject.tag != "Player")
            {
                gameObject.GetComponent<CharacterControllerAction>().ActiveSuperPower();
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
            }
        }
    }
}
