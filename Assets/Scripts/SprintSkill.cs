using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintSkill : Skill
{
    public AudioSource audioSource;

    // CharacterControllerMovement movement;
    Rigidbody rb;
    public float acceleration = 9000;
    public GameObject teleportPrefab;
    ParticleSystem teleportOrigin;
    ParticleSystem teleportEnd;

    private void Start()
    {
        teleportOrigin = Instantiate(teleportPrefab, skillSpawnPoint.position, transform.rotation).GetComponent<ParticleSystem>();
        teleportOrigin.transform.SetParent(transform);

        teleportEnd = Instantiate(teleportPrefab, skillSpawnPoint.position, transform.rotation).GetComponent<ParticleSystem>();
        teleportEnd.transform.SetParent(transform);
        rb = GetComponent<Rigidbody>();
    }

    protected override void ActiveSkill()
    {
        audioSource.Play();
        teleportOrigin.Emit(100);
        rb.AddForce(transform.forward * acceleration, ForceMode.Acceleration);
        Invoke("EmitEnd", 0.1f);
    }

    void EmitEnd()
    {
        teleportEnd.Emit(100);
    }
}
