using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float maxHealth = 20;
    public float health;
    private Animator anim;
    private SpriteRenderer spriteRender;

    private PointAndShoot shootingScript;



    public float speed = 1.5f;
    private Rigidbody2D rb;

    Vector2 movement;
    public bool isDead;
    [SerializeField]
    private float dodgeForce = 50f;

    //TODO: IFrames.

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRender = GetComponent<SpriteRenderer>();
        shootingScript = FindObjectOfType<PointAndShoot>();
        health = maxHealth;
    }

    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        Death();

        //animations
        

        if (shootingScript.attacked == true)
        {
            anim.SetBool("Attacked", true);
        }
        else
        {
            anim.SetBool("Attacked", false);
        }
        //End of Animations
    }



    private void FixedUpdate()
    {
 //TODO: do something for the dodge uwa
        rb.MovePosition(rb.position + movement.normalized * speed *Time.fixedDeltaTime);
        if (Input.GetMouseButtonDown(1))
        {
            dodge();
            Debug.Log("DODGE?");
        }
    }


    private void dodge()
    {
        rb.AddForce(movement.normalized * dodgeForce, ForceMode2D.Impulse);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //empty for now... damage moved into PlayerHitbox Script.
    
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
            Destroy(rb);
            anim.SetBool("Dead", true);
            isDead = true;
        }
    }
}
