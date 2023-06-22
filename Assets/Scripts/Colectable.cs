using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colectable : MonoBehaviour
{
    private PlayerManager playerManager;
    public bool canBeCollected = true;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && canBeCollected)
        {
            playerManager = other.gameObject.GetComponent<PlayerManager>();
            playerManager.candyCounter++;
            Destroy(gameObject);
        }
    }
}
