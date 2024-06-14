using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objetoTerremoto : MonoBehaviour
{
    private bool triggerOcurrido = false; // Bandera para controlar si ya ocurrió el trigger
    private float destructionDelay = 5.0f;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && !triggerOcurrido) // Verifica si el tag es "Player" y el trigger no ha ocurrido
        {
            Debug.Log("entro a terremoto");
            CineMachineMovimientoCamara.Instance.MoverCamara(20, 5, 1.7f);
            Destroy(gameObject, destructionDelay);
            triggerOcurrido = true; // Establece la bandera a true para indicar que el trigger ya ha ocurrido
        }
    }
}
