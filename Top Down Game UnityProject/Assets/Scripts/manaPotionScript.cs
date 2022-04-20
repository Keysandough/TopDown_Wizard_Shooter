using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manaPotionScript : MonoBehaviour
{
    private PointAndShoot magicSys;

    private Rigidbody2D rigidBody;
    private Vector2 dropDir;
    private float force = 50f;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        magicSys = FindObjectOfType<PointAndShoot>();
        dropDir.x = Random.Range(-1, 1);
        dropDir.y = Random.Range(-1, 1);

        rigidBody.AddForce(dropDir * force);
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag ("Player") && (magicSys.mana != magicSys.maxMana))
        {
            Destroy(this.gameObject);
            magicSys.mana = magicSys.maxMana;
            Debug.Log("MANA POTION");
        }
    }

}
