using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatBar : MonoBehaviour
{
    public Image manaBarSprite;
    public Image healthBarSprite;

    public float CurrentMana;
    public float CurrentHealth;

    public float _MaxMana;
    public float _MaxHealth;

    Player playerScript;
    PointAndShoot ManaScript;

    private void Start()
    {
        playerScript = FindObjectOfType<Player>();
        ManaScript = FindObjectOfType<PointAndShoot>();
        _MaxMana = ManaScript.maxMana;
        _MaxHealth = playerScript.maxHealth;
    }

    private void Update()
    { 
        CurrentMana = ManaScript.mana;
        manaBarSprite.fillAmount = CurrentMana / _MaxMana;

        CurrentHealth = playerScript.health;
        //Debug.Log(CurrentHealth);
        healthBarSprite.fillAmount = CurrentHealth / _MaxHealth;
    }
}
