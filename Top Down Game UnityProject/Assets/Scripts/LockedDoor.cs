using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LockedDoor : MonoBehaviour
{
    private ManagerScript manager;
    private void Start()
    {
        manager = FindObjectOfType<ManagerScript>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && manager.gotKey == true)
        {
            StartCoroutine(destroyDoor(1.0f));
            
        }
        
        IEnumerator destroyDoor(float waitTime)
        {
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(waitTime);
            Destroy(this.gameObject);
        }
    }
}
