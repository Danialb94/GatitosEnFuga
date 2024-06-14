using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataformas : MonoBehaviour
{
    public List<GameObject> plataformas;
    private MovimientoJugador movimientoJugador;

    private void Start()
    {
        movimientoJugador = GameObject.FindGameObjectWithTag("Player").GetComponent<MovimientoJugador>();
        movimientoJugador.OnJump += Activar;
    }

    private void Activar (object sender, EventArgs e)
    {
        foreach(GameObject item  in plataformas)
        {
            item.SetActive(!item.activeSelf);
        }
      
    }
}
