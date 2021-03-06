using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrelScript : MonoBehaviour
{
    public GameObject brokenBarrel;
    public GameObject coinPrefab;
    public GameObject ManaPotion;
    public GameObject healthPotion;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.tag == "Projectile")
        {
            Destroy(this.gameObject);
            Instantiate(brokenBarrel, transform.position, Quaternion.identity);
            int randNum = Random.Range(0, 2);
            if (randNum == 0) {
                Instantiate(healthPotion, this.transform.position, Quaternion.identity);
            }
            else { 
                Instantiate(ManaPotion, this.transform.position, Quaternion.identity);
            }

            int coinNumber = Random.Range(0, 6);
            for (int i = 0; i < coinNumber; i++)
            {
                Instantiate(coinPrefab, this.transform.position, Quaternion.identity);
            }
        }
    }
}
