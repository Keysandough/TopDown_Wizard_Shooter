using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public GameObject SpawnLoc;
    public GameObject Boss;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(Boss, SpawnLoc.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
