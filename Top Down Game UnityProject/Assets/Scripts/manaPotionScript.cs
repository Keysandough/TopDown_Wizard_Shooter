using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manaPotionScript : MonoBehaviour
{
    private PointAndShoot magicSys;

    private Rigidbody2D rigidBody;
    private float force = 8f;
    private GameObject player;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        player = GameObject.Find("CoinCollector");

        magicSys = FindObjectOfType<PointAndShoot>();
        Vector2 dir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        rigidBody.AddForce(dir * force);

    }
    private void Update()
    {
        //moving toward player.
        if (Vector3.Distance(transform.position, player.transform.position) < 0.5f && magicSys.mana != magicSys.maxMana)
        {
            Vector2 targetTransform = Vector2.MoveTowards(transform.position, player.transform.position, 10 * Time.deltaTime);
            rigidBody.MovePosition(targetTransform);

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag ("Player") && (magicSys.mana != magicSys.maxMana))
        {
            Destroy(this.gameObject);
            magicSys.mana = magicSys.maxMana;
            //Debug.Log("MANA POTION");
        }
    }

}
