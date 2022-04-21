using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float health = 20;

    public bool keyBearer = false;
    

    [SerializeField]private float speed;
    private Transform target;
    private Rigidbody2D enemyrb;
    private SpriteRenderer sprite;

    public GameObject corpse;

    public GameObject manaPotion;
    public GameObject coinPrefab;
    public GameObject key;

    private int coinNumber;

    private ManagerScript managerScript;

    


    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemyrb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        managerScript = FindObjectOfType<ManagerScript>();
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

            Destroy(this.gameObject);
        }
    }
   
    
    private void OnDestroy()
    {
        Instantiate(corpse, this.transform.position, Quaternion.identity);

        if (keyBearer == true)
        { Instantiate(key, transform.position, Quaternion.identity); }

        //POTION DROP
        if (Random.Range(0, 9) > 6)
        {
            Instantiate(manaPotion, transform.position, Quaternion.identity);
        }
        //COIN DROP
        coinNumber = Random.Range(0, 6);
        for (int i = 0; i < coinNumber; i++)
        {
            Instantiate(coinPrefab, this.transform.position, Quaternion.identity);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Projectile")
        {
            float rawDamage = Random.Range(2, 6);
            float damage = rawDamage * managerScript.playerDamageMod;
            health -= damage;
            Debug.Log("DAMAGE " + damage);
        }

    }

    
}
