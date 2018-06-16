using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    [SerializeField] protected KeyCode activeSkillKey;
    protected abstract void ActiveSkill();
    protected GameObject skillParticles;

    [SerializeField] GameObject skillParticlesPrefab;
    [SerializeField] protected float coolDown;

    private void Start()
    {
        InstantiateParticles();
    }

    protected void InstantiateParticles()
    {
        skillParticles = Instantiate(skillParticlesPrefab, transform.position, Quaternion.identity);
    }
}
