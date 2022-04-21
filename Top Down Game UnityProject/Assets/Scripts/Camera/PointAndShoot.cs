using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class PointAndShoot : MonoBehaviour
{
    public Vector3 camTarget;
    public GameObject Crosshairs;
    public GameObject firePoint;
    public GameObject Player;
    public Player playerScript;



    public float maxMana = 15f;
    //maxMAna Should be 15f
    public float mana;
    private float manaRegen = 0.4f;

    private float manaCost = 1.0f;

   


    public GameObject bullet;
    public float bulletSpeed = 5f;


    public Image notEnoughMana;

    


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        FaceMouseLoc();
        manaManager();
        
        if (mana * 100 < maxMana * 100 / 3)
        {
            notEnoughMana.gameObject.SetActive(true);
        }
        else
        {
            notEnoughMana.gameObject.SetActive(false);
        }



        camTarget = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        Crosshairs.transform.position = new Vector2(camTarget.x, camTarget.y);

        Vector3 difference = camTarget - firePoint.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        if (Input.GetMouseButtonDown(0))
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            fireProjectile01(direction, rotationZ);

        }
    }





    void fireProjectile01(Vector2 direction, float rotationZ)
    {
        if (mana > manaCost)
        {
            GameObject b = Instantiate(bullet) as GameObject;
            b.transform.position = firePoint.transform.position;
            b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
            mana--;
        }
        else
        {
            //NOT ENOUGH MANA
            
        }
        
    }

    private void manaManager()
    {
        if (mana > maxMana)
        {
            mana = maxMana;
        }
        if (mana == maxMana)
        {
            return;
        }
        else
        {
            mana += manaRegen * Time.deltaTime;
            //Debug.Log(mana);
        }

        if (mana > maxMana)
        {
            mana = maxMana;
        }
    }








    //for character facing in X (left and right)
    private void FaceMouseLoc()
    {
        if (Crosshairs.transform.position.x > Player.transform.position.x)
        {
           // Debug.Log("right");
            Player.GetComponent<Transform>().localScale = new Vector3(1, Player.transform.localScale.y, Player.transform.localScale.z);
        }
        else
        {
          // Debug.Log("left");
            Player.GetComponent<Transform>().localScale = new Vector3(-1, Player.transform.localScale.y, Player.transform.localScale.z);

        }
    }
}
