using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float maxHealth = 20;
    public float health;
    private Animator anim;
    private SpriteRenderer spriteRender;

    private PointAndShoot shootingScript;
    private PlayerDodgeCooldown dodgeCDScript;
    public GameObject hitBox;


    public float speed = 1.5f;
    private Rigidbody2D rb;

    Vector2 movement;
    public bool isDead;
    public bool dodged = false;
    [SerializeField]
    private float dodgeForce = 50f;

    //TODO: IFrames.

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRender = GetComponent<SpriteRenderer>();
        shootingScript = FindObjectOfType<PointAndShoot>();
        dodgeCDScript = FindObjectOfType<PlayerDodgeCooldown>();
        health = maxHealth;
    }

    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        Death();
        if (Input.GetKeyDown(KeyCode.Space) && dodged == false)
        {
            Debug.Log("DODGE?");
            dodge();
        }

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
        rb.MovePosition(rb.position + movement.normalized * speed *Time.fixedDeltaTime);
        
    }


    private void dodge()
    {
        dodged = true;
        hitBox.GetComponent<CapsuleCollider2D>().enabled = false;
        spriteRender.color = Color.gray;
        rb.AddForce(150 * movement * 10, ForceMode2D.Force);

        StartCoroutine(dodgeCDScript.EnableBox(dodgeCDScript.dodgeCooldown));
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
