using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealMusica : MonoBehaviour
{
    public AudioClip clipHeal;
    private void OnTriggerEnter2D(Collider2D col)
    {
        AudioSource.PlayClipAtPoint(clipHeal, new Vector3(5, 1, 2));
    }
}
