using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoTerremoto : MonoBehaviour
{
    public AudioClip ter;
    private void OnTriggerEnter2D(Collider2D colission)
    {
        AudioSource.PlayClipAtPoint(ter, new Vector3(5, 1, 2));
    }
}
