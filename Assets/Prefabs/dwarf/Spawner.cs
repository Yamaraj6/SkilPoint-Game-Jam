using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject prefab;
    public float spawnTimeMin;
    public float spawnTimeMax;
    Timer tRestart = new Timer();

    private void Update()
    {
        if(tRestart.isReadyRestart())
        {
            Instantiate(prefab, transform.position, transform.rotation);
            tRestart.cd = Random.Range(spawnTimeMin, spawnTimeMax);
        }
    }
}
