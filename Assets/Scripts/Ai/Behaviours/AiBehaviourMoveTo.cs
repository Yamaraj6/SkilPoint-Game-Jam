using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiBehaviourMoveTo : AiBehaviourBase
{
    AiMovement movement;

    new protected void Start()
    {
        base.Start();
        movement = GetComponentInParent<AiMovement>();
    }

    public AiLocationBase aim;
    public float stopDistance;
    public float movementSpeed;

    public override bool PerformAction()
    {
        Vector2 point = aim.GetLocation();
        Vector2 inf = (point - new Vector2(movement.transform.position.x, movement.transform.position.z) );

        float sqMag = inf.sqrMagnitude;
        inf.Normalize();
        if (sqMag > stopDistance * stopDistance)
        {
            movement.ApplyInfluencePosition(inf * movementSpeed);
        }
        movement.SetRotation(Vector2.Angle(Vector2.up, inf) * (inf.x > 0 ? 1 : -1));

        return true;
    }
}