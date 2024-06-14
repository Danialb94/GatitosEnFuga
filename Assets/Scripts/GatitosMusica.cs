using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatitosMusica : MonoBehaviour
{
    public AudioClip maullido;
    private void OnTriggerEnter2D(Collider2D coli)
    {
        if (coli.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(maullido, new Vector3(5, 1, 2));
        }
    }
}
