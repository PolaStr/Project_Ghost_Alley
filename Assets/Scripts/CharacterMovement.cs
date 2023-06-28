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
    public Camera cam;

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

        if (Input.GetMouseButtonDown(1))
        {
            cam.transform.position = new Vector3(-3.5940001f, 3.7479558f, -6.87699986f);
            cam.transform.rotation = new Quaternion(0.254190862f, 0.658472002f, -0.25298205f, 0.661665916f);
        }
        else if (Input.GetMouseButtonDown(0))
        {
            cam.transform.position = new Vector3(0.901608825f, 3.7479558f, -3.70607209f);
            cam.transform.rotation = new Quaternion(-0.0610680021f, 0.919853508f, -0.353388697f, -0.1589237f);
        }
    }
}