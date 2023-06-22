using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(Input.GetKey(KeyCode.E))
            {
                if(!this.animator.GetCurrentAnimatorStateInfo(0).IsName("Close") || !this.animator.GetCurrentAnimatorStateInfo(0).IsName("Open"))
                animator.SetTrigger("DoorTrigger");
            }
        }
    }
}
