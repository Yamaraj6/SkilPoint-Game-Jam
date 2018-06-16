using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float time=2;
    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, time);
    }
}
