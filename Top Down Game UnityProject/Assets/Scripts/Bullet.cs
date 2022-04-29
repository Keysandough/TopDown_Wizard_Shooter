using UnityEngine;

public class Bullet : MonoBehaviour
{ 
    public GameObject fx;
    public GameObject simpleFX;
    [SerializeField] float range = 3.0f;

    private void Update()
    {
        Destroy(this.gameObject, range);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Instantiate(fx, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
        else if (collision.CompareTag("Boss"))
        {
            Instantiate(fx, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
        else if (collision.CompareTag("Destructable"))
        {
            Instantiate(simpleFX, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
        
        
    }

}
