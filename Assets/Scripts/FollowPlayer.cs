using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent nav;
    bool touchh = false;

    public void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.enabled = false;
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            touchh = true;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown("e") && touchh == true)
        {
            nav.enabled = true;
        }
        nav.SetDestination(target.position);
    }
}
