using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyMachine : MonoBehaviour
{
    [SerializeField] private GameObject candyPrefab;
    [SerializeField] private Transform spawnPlace;
    private Rigidbody prefabRB;

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("kliknij");

        if (Input.GetKey(KeyCode.E))
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("dodaj");
                var gameobject = Instantiate(candyPrefab,spawnPlace);
                gameobject.GetComponent<Rigidbody>().AddForce(Vector3.forward);
                StartCoroutine(waitSecond(gameobject));
                Destroy(gameobject.GetComponent<Rigidbody>());
                
            }
        }

    }
    IEnumerator waitSecond(GameObject gameobject)
    {
        yield return new WaitForSeconds(1f);
        gameobject.transform.SetParent(null);
        gameobject.GetComponent<Colectable>().canBeCollected = true;
    }
}
