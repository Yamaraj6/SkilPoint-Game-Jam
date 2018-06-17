using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Mine mine = other.GetComponent<Mine>();
      
        if (!mine) return;
        Debug.Log(other.gameObject.name);
        mine.Explosion();
    }

}
