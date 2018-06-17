using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSkill : Skill
{
    public float strength = 100;

    protected override void ActiveSkill()
    {

        GameObject spawned = Instantiate(skillParticlesPrefab, skillSpawnPoint.position, transform.rotation);

        spawned.GetComponent<Rigidbody>().AddForce(transform.forward * strength);
    }

    void EnableCollider()
    {

    }
}
