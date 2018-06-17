using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterControllerRB))]
public class CharacterControllerAction : MonoBehaviour {
    Animator animator;
    private CharacterControllerRB characterController;

    private void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponentInChildren<CharacterControllerRB>();
    }

    public void ActiveSuperPower()
    {
    //    animator.SetTrigger("Moving");
        characterController.isBusy = true;
    }
    
}
