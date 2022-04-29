using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManagerScript : MonoBehaviour
{
    public int coinCount;
    private int lastCoinCount;

    public TextMeshProUGUI coinText;

    public GameObject player;
    public float playerDamageMod = 1;

    public GameObject keyIcon;
    public bool gotKey = false;
  


    private AudioSource coinAudio;

    private void Start()
    {
        coinAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        transform.position = player.transform.position;
        // see If coin was changed in order to play the sound;
        if (lastCoinCount != coinCount)
        {
            coinAudio.Play();
            lastCoinCount = coinCount;
        }

        coinText.text = coinCount.ToString();

        if (keyIcon.activeSelf) // which is activated in the Key Script.
        {
            gotKey = true;
        }
    }


    

}
