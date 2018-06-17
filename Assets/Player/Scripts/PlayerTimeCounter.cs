using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTimeCounter : MonoBehaviour
{
    public float _survivedTime = 0;
    // Use this for initialization
    private bool _stopCounting = false;

    // Update is called once per frame
    private void Update()
    {
        if (_stopCounting)
            return;

        _survivedTime += Time.deltaTime;
    }

    public void StopCounting()
    {
        _stopCounting = true;
    }
}