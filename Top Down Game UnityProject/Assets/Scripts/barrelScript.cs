using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrelScript : MonoBehaviour
{
    public GameObject brokenBarrel;
    public GameObject coinPrefab;
    public GameObject ManaPotion;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.tag == "Projectile")
        {
            Destroy(this.gameObject);
            Instantiate(brokenBarrel, transform.position, Quaternion.identity);

            Instantiate(ManaPotion, this.transform.position, Quaternion.identity);

            int coinNumber = Random.Range(0, 6);
            for (int i = 0; i < coinNumber; i++)
            {
                Instantiate(coinPrefab, this.transform.position, Quaternion.identity);
            }
        }
    }
}
