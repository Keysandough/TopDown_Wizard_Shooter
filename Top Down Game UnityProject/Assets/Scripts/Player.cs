using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float maxHealth = 20;
    public float health;


    public float speed = 1.5f;
    private Rigidbody2D rb;

    Vector2 movement;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }

    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        Death();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * speed *Time.fixedDeltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage();
            //Debug.Log("Ouch! Remaning HP:" + health);
        }
    
    }


    void TakeDamage()
    {
        health -= Random.Range(1, 5);
    }

    void Death()
    {
        if (health <= 0)
        {
            //place the death anim 
            Destroy(this.gameObject);
        }
    }
}
