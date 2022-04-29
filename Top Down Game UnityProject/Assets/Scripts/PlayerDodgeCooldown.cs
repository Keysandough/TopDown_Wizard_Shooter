using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDodgeCooldown : MonoBehaviour
{
    [SerializeField]
    public float dodgeCooldown = 1.4f;
    private playerHitboxScript _playerHitbox;
    private Player _player;
    public GameObject Hitbox;
    private SpriteRenderer sprite;

    private void Awake()
    {
        _playerHitbox = FindObjectOfType<playerHitboxScript>();
        _player = FindObjectOfType<Player>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame

    public IEnumerator EnableBox(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _player.dodged = false;
        Hitbox.GetComponent<CapsuleCollider2D>().enabled = true;
        sprite.color = Color.white;
    }
}
