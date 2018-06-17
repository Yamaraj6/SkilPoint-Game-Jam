using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEventPhysicsDestruction : MonoBehaviour
{
    public GameObject[] destructedObjects;
    public float drag;
    public float collRadius;
    public float removeTime;

    void OnDeath(HealthController.DamageData data)
    {
        foreach(var it in destructedObjects)
        {
            var rb = it.AddComponent<Rigidbody>();
            if(!rb)
                continue;

            rb.drag = drag;
            var coll = it.AddComponent<SphereCollider>();
            
            if(!coll)
                continue;

            coll.radius = collRadius;
            var remove = it.gameObject.AddComponent<RemoveAfterDelay>();

            if(!remove)
                continue;

            remove.timer = new Timer(removeTime);

            it.transform.parent = null;
        }

    }

}
