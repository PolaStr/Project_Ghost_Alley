using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public GameObject player;
    bool doOnce = true;
    bool touch = false;
    void InstantiateNewObject()
    {
        Instantiate(objectToSpawn, new Vector3(1.27400005f, 1.67709994f, -6.98799992f), Quaternion.identity);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            touch = true;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown("space") && doOnce == true && touch == true)
        {
            InstantiateNewObject();
            doOnce = false;
        }
    }
}
