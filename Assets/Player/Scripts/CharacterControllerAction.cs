using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterControllerRB))]
public class CharacterControllerAction : MonoBehaviour {
    public float timeThrowObject=0.4f;
    public float timeSuperPower=0.8f;
    Animator animator;
    CharacterControllerRB characterController;

    private void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterControllerRB>();
    }

    public void ActiveSuperPower()
    {
        animator.SetTrigger("SuperPowerTrigger");
        characterController.BeBusy(timeSuperPower);
    }

    public void ThrowObject()
    {
        animator.SetTrigger("ThrowTrigger");
        characterController.BeBusy(timeThrowObject);
    }
}
