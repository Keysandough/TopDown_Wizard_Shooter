using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private ManagerScript managerScript;
    private Rigidbody2D rigidBody;
    private float force = 60f;

    private GameObject player;


    private void Start()
    {
        player = GameObject.Find("CoinCollector");
        //for counting stuff
        managerScript = FindObjectOfType<ManagerScript>();

        rigidBody = GetComponent<Rigidbody2D>();

        Vector2 dir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        rigidBody.AddForce(dir * force);
    }

    private void Update()
    {
        //Coin Moving Toward Player if close enough.
        if (Vector3.Distance(transform.position, player.transform.position) < 0.7f)
        {
            Vector2 targetTransform = Vector2.MoveTowards(transform.position, player.transform.position, 10 * Time.deltaTime);
            rigidBody.MovePosition(targetTransform);

        }
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
