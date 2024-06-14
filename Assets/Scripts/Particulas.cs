using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particulas : MonoBehaviour
{
    public ParticleSystem particulasdamage;

    public void ParticulasInician()
    {
        particulasdamage.Play();

    }
}