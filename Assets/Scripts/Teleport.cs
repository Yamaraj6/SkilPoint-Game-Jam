using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : Skill
{
    public GameObject prefab;
    ParticleSystem origin;
    ParticleSystem end;
    Rigidbody rb;
    public AudioSource audioSource;
    public float force = 10000;

    protected override void ActiveSkill()
    {
        audioSource.Play();
        origin.Emit(40);
        origin.transform.position = transform.position;
        rb.AddForce(transform.forward * force, ForceMode.Acceleration);
        EmitEnd();
    }

    void EmitEnd()
    {
        end.transform.position = transform.position;
        end.Emit(40);
    }

    override protected void Start()
    {
        rb = GetComponent<Rigidbody>();
        base.Start();
        origin = Instantiate(prefab, transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
        // origin.transform.SetParent(transform);

        end = Instantiate(prefab, transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
        end.transform.SetParent(transform);


        coolDown = GameObject.FindGameObjectWithTag("TeleportSkill").GetComponent<CoolDown>();
    }
}
