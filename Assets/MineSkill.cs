using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSkill : Skill
{
    public float strength = 100;

    override protected void Start()
    {
        base.Start();
        coolDown = GameObject.FindGameObjectWithTag("Mine").GetComponent<CoolDown>();
    }

    protected override void ActiveSkill()
    {
        gameObject.GetComponent<CharacterControllerAction>().ThrowObject();

        GameObject spawned = Instantiate(skillParticlesPrefab, skillSpawnPoint.position, transform.rotation);

        spawned.GetComponent<Rigidbody>().AddForce(transform.forward * strength);
    }

}
