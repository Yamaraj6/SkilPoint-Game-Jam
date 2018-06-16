using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    [SerializeField] protected KeyCode activeSkillKey;
    protected abstract void ActiveSkill();
    [SerializeField] Transform skillSpawnPoint;

    [SerializeField] protected GameObject skillParticlesPrefab;
    [SerializeField] protected float coolDown;

    protected void InstantiateParticles()
    {
        Instantiate(skillParticlesPrefab, skillSpawnPoint.position,transform.rotation );
    }

    private void Update()
    {
        if (Input.GetKeyDown(activeSkillKey))
            ActiveSkill();
    }
}
