using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeBallSkill : Skill
{


    protected override void ActiveSkill()
    {
        gameObject.GetComponent<CharacterControllerAction>().ActiveSuperPower();
        InstantiateParticles();
    }
}
