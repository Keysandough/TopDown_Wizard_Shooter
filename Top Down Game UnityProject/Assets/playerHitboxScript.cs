using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerHitboxScript : MonoBehaviour
{
    private Player player;
    [SerializeField] private float cooldown;

    void Start()
    {
        player = FindObjectOfType<Player>();


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            player.health -= 2 + Random.Range(0, 4);

            GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(EnableBox(cooldown));
        }
    }
    IEnumerator EnableBox(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GetComponent<BoxCollider2D>().enabled = true;
    }

}
