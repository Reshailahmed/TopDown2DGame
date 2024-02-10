using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPickUp : MonoBehaviour
{
    public ManaBar mana;
    public GrappleHook grappleHook;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            mana.SetMana(10);
            grappleHook.currMana = 10;
            Destroy(gameObject);
        }
    }
}
