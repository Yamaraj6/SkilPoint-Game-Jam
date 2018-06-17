using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public GameObject explodeEffect;
    public GameObject model;
    AudioSource groundHitSnd;
    Collider collider;
    bool isGrounded;


    private void Start()
    {
        collider = GetComponent<Collider>();
        groundHitSnd = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            groundHitSnd.Play();
            isGrounded = true;
        }

        if (!isGrounded) return;
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Player"
            || collision.gameObject.tag == "Explosion")
        {
            Explosion();
        }
    }

    public void Explosion()
    {
        GetComponent<Collider>().enabled = false;
        Instantiate(explodeEffect, transform.position, Quaternion.identity);
        model.SetActive(false);
    }
}
