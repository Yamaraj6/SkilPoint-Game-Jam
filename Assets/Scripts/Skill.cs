using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    [SerializeField] protected KeyCode activeSkillKey;
    protected abstract void ActiveSkill();
    [SerializeField] protected Transform skillSpawnPoint;

    [SerializeField] protected GameObject skillParticlesPrefab;
    [SerializeField] public CoolDown coolDown;

    protected void InstantiateParticles()
    {
        Instantiate(skillParticlesPrefab, skillSpawnPoint.position,transform.rotation );
    }

    private void Update()
    {
        if (Input.GetKeyDown(activeSkillKey) && !coolDown._isLerping)
        {
            ActiveSkill();
            coolDown.StartLerping();
        }
    }
}
