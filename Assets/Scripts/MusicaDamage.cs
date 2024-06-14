using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaDamage : MonoBehaviour
{
    public AudioClip musica;
    private void OnTriggerEnter2D(Collider2D col)
    {
        AudioSource.PlayClipAtPoint(musica, new Vector3(5, 1, 2));
    }
}
