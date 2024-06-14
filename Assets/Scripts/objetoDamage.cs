using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objetoDamage : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out vidaJugador vidaJugador))
        {
           Debug.Log("entro al trigger");
            other.SendMessage("ParticulasInician");
            vidaJugador.TomarDanio(damage);
        }
    }
}
