using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manaPotionScript : MonoBehaviour
{
    private PointAndShoot magicSys;

    private Rigidbody2D rigidBody;
    private float force = 70f;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        magicSys = FindObjectOfType<PointAndShoot>();
        Vector2 dir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        rigidBody.AddForce(dir * force);

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
