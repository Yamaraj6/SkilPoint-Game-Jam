using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeBallSkill : Skill
{
    override protected void Start()
    {
        base.Start();
        coolDown = GameObject.FindGameObjectWithTag("Freeze").GetComponent<CoolDown>();
    }

    protected override void ActiveSkill()
    {
        gameObject.GetComponent<CharacterControllerAction>().ActiveSuperPower();
        InstantiateParticles();
    }
}
