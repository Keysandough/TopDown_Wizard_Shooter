using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerHitboxScript : MonoBehaviour
{
    private Player player;
    private SpriteRenderer playerSprite;
    [SerializeField] private float cooldown;

    void Start()
    {
        player = FindObjectOfType<Player>();
        playerSprite = player.GetComponent<SpriteRenderer>();

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            player.health -= 2 + Random.Range(0, 4);

            GetComponent<CapsuleCollider2D>().enabled = false;
            StartCoroutine(EnableBox(cooldown));
            playerSprite.color = Color.red;
            
        }
    }
    IEnumerator EnableBox(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GetComponent<CapsuleCollider2D>().enabled = true;
        playerSprite.color = Color.white;
    }

}
