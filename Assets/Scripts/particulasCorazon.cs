using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticulasCorazon : MonoBehaviour
{
    public ParticleSystem particulasheart;

    public void ParticulasInicia()
    {
        particulasheart.Play();

    }
}