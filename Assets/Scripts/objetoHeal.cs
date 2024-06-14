using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objetoHeal : MonoBehaviour
{
    public int heal;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out vidaJugador vidaJugador))
        {
            vidaJugador.CurarVida(heal);
            Destroy(gameObject);
        }
    }
}
