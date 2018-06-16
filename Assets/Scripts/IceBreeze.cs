using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBreeze : Skill
{
    protected override void ActiveSkill()
    {
        GameObject skill = Instantiate(skillParticlesPrefab, transform.position, Quaternion.identity);
        skill.transform.SetParent(transform);
    }
}
