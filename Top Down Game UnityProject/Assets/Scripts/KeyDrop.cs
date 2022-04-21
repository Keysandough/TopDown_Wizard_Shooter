using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDrop : MonoBehaviour
{
    public GameObject keyHolder;
    public GameObject KeySpawn;
    private Vector3 spawnLocation;

    public GameObject Key;
    private bool isAlive;
    private void Start()
    {
        spawnLocation = KeySpawn.GetComponent<Transform>().position;
    }
    private void Update()
    {
        if (keyHolder != null)
        {
            isAlive = true;
        }
        else
        {
            isAlive = false;
        }

        if (isAlive == false)
        {
            Instantiate(Key, spawnLocation, Quaternion.identity);
            Debug.Log("DROPPED");
        }
        
    }
}
