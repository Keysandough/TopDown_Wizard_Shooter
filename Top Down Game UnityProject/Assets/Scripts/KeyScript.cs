using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public GameObject _keyIcon;
    public ManagerScript managerScript;

    private void Start()
    {
        managerScript = FindObjectOfType<ManagerScript>();
        _keyIcon = managerScript.keyIcon;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _keyIcon.gameObject.SetActive(true); //this is gonna be checked in ManagerScript to detemine if a bool is true or not (for later encountering doors)
            Destroy(this.gameObject);
        }
    }
}
