using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class healthPotionScript : MonoBehaviour
{
    private Player playerScript;
    private Rigidbody2D rigidBody;
    private float force = 8f;
    private GameObject player;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerScript = FindObjectOfType<Player>();
        Vector2 dir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        rigidBody.AddForce(dir * force);
        player = GameObject.Find("CoinCollector");
    }
    private void Update()
    {//moving toward player
        if (Vector3.Distance(transform.position, player.transform.position) < 0.5f && playerScript.health != playerScript.maxHealth)
        {
            Vector2 targetTransform = Vector2.MoveTowards(transform.position, player.transform.position, 10 * Time.deltaTime);
            rigidBody.MovePosition(targetTransform);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && (playerScript.health != playerScript.maxHealth))
        {
            Destroy(this.gameObject);
            playerScript.health = playerScript.maxHealth;
            //Debug.Log("Health POTION");
        }
    }
}
