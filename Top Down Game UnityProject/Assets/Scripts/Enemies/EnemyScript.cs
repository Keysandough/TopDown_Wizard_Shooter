using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int health = 20;

    [SerializeField]private float speed;
    private Transform target;
    private Rigidbody2D enemyrb;
    private SpriteRenderer sprite;

    public GameObject corpse;

    public GameObject manaPotion;
    public GameObject coinPrefab;

    private int coinNumber;

    


    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemyrb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        Death();
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        //Rotation
        if (target.transform.position.x < this.transform.position.x)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
    }



    private void Death()
    {
        if (health <= 0)
        {
            Instantiate(corpse, this.transform.position, Quaternion.identity);

            
            //CHANGE FROM MANA POTION TO COIN I THINK: DONE
            //COIN DROP
            coinNumber = Random.Range(0, 6);
            for (int i = 0; i < coinNumber; i++)
            {
                Instantiate(coinPrefab, this.transform.position, Quaternion.identity);
            }
            

            Destroy(this.gameObject);
        }
    }

    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Projectile")
        {
            GettingHit();
        }

    }

    private void GettingHit()
    {
        Debug.Log("health: " + health);
        health -= Random.Range(1, 6);
    }
}
