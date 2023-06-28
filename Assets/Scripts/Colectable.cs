using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Colectable : MonoBehaviour
{
    public PlayerManager playerManager;
    public bool canBeCollected = true;
    public TextMeshProUGUI counter;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && canBeCollected)
        {
                playerManager = other.gameObject.GetComponent<PlayerManager>();
                PlayerManager.candyCounter++;
                Destroy(gameObject);
                counter.text = (PlayerManager.candyCounter).ToString();

            if (PlayerManager.candyCounter > 8)
            {
                counter.text = ("8");
            }
        }

    }
}
