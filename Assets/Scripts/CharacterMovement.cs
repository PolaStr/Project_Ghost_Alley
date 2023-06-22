using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private CharacterController cc;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;
    private float sidewayMovement;
    private float forwardMovement;
    private float verticalVelocity;

    private void Update()
    {
        forwardMovement = Input.GetAxis("Horizontal") * moveSpeed;
        sidewayMovement = Input.GetAxis("Vertical") * moveSpeed;
        Vector3 playerDirect = new Vector3(-forwardMovement, 0, -sidewayMovement);
        verticalVelocity += Physics.gravity.y * Time.deltaTime;

        if (playerDirect != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(playerDirect, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotateSpeed * Time.deltaTime);
        }

        Vector3 playerMovement = new Vector3 (playerDirect.x, verticalVelocity, playerDirect.z);
        cc.Move(playerMovement * Time.deltaTime);
    }
}