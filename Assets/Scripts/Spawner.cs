using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public GameObject player;
    bool doOnce = true;
    bool touch = false;
    public TextMeshProUGUI tmp;
    void InstantiateNewObject()
    {
        var clone = Instantiate(objectToSpawn, new Vector3(1.27400005f, 1.67709994f, -6.98799992f), Quaternion.identity);
        var colectable = clone.AddComponent<Colectable>();
        colectable.counter = tmp;
        PlayerManager.candyCounter--;
    }
    public void OnTriggerEnter(Collider other)
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
