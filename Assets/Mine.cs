using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public GameObject explodeEffect;
    public GameObject model;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Player")
        {
            GetComponent<Collider>().enabled = false;
            Instantiate(explodeEffect, transform.position, Quaternion.identity);
            model.SetActive(false);
        }
    }
}
