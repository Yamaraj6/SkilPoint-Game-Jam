using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : Skill
{
    GameObject prefab;
    ParticleSystem origin;
    ParticleSystem end;

    protected override void ActiveSkill()
    {
        origin.Emit(40);
        Invoke("emitEnd", 0.15f);
    }

    void EmitEnd()
    {
        end.Emit(40);
    }

    override protected void Start()
    {
        base.Start();
        origin = Instantiate(prefab, transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
        origin.transform.SetParent(transform);

        end = Instantiate(prefab, transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
        end.transform.SetParent(transform);


        coolDown = GameObject.FindGameObjectWithTag("Push").GetComponent<CoolDown>();
    }
}
