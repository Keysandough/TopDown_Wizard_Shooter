using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private ManagerScript managerScript;
    private Rigidbody2D rigidBody;
    private Vector2 dropDir;
    private float force = 60f;

    private void Start()
    {
        //for counting stuff
        managerScript = FindObjectOfType<ManagerScript>();

        rigidBody = GetComponent<Rigidbody2D>();
        dropDir.x = Random.Range(-1, 1);
        dropDir.y = Random.Range(-1, 1);
        rigidBody.AddForce(dropDir * force);




    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            //sound of coin should go here
                    //it went to gameManager;

            

            managerScript.coinCount++;
        }
        
    }
}
