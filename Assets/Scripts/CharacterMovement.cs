using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private CharacterController cc;

    private float vertical;
    private float horizontal;
    private float gravity;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;

    private void Update()
    {
        gravity = Physics.gravity.y * Time.deltaTime;
        vertical = Input.GetAxis("Vertical") * speed;
        horizontal = Input.GetAxis("Horizontal") * speed;

        Vector3 playerVector = new Vector3(-horizontal, 0, -vertical);

        cc.Move(playerVector * Time.deltaTime);
        
        if (playerVector != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(playerVector, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}