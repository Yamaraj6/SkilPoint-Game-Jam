using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachAiStun : AttachBase {

    AiUnitMind mind;
    AiMovement movement;
    new private void Start()
    {
        base.Start();
        mind = GetComponentInParent<AiUnitMind>();
        if (mind)
            mind.enabled = false;

        movement = GetComponentInParent<AiMovement>();
        if (movement)
            movement.enabled = false;
    }


    private void OnDestroy()
    {
        if (mind)
            mind.enabled = true;
        if (movement)
            movement.enabled = true;
    }
}
