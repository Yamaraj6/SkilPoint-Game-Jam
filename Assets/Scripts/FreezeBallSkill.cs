using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeBallSkill : Skill
{


    protected override void ActiveSkill()
    {
        InstantiateParticles();
    }
}
