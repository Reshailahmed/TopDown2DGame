using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletHit : MonoBehaviour
{
    public PlayerController1 player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");
        if (collision.gameObject.CompareTag("Fireball"))
        {
            player.Health -= 1;
            Destroy(collision.gameObject);
        }
    }
}
