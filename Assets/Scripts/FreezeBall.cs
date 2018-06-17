using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeBall : MonoBehaviour
{
    public GameObject collisionParticlePrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Destructable" || other.gameObject.tag == "tree")
        {
            Instantiate(collisionParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject,0.3f);
        }
    }


}
