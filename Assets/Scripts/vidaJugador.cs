using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class vidaJugador : MonoBehaviour
{
    public int totalVidas = 3; // Número total de vidas
    private int vidasRestantes;
    public int vidaActual;

    public int vidaMaxima = 3;

    public UnityEvent<int> cambioVida; // Evento que se invoca cuando cambia la vida
    private Vector3 posicionInicial;

    // Start is called before the first frame update
    void Start()
    {
        vidasRestantes = totalVidas;
        vidaActual = vidaMaxima;
        posicionInicial = transform.position;
        cambioVida.Invoke(vidaActual);
    }

    public void TomarDanio(int cantidadDanio)
    {
        int vidaTemporal = vidaActual - cantidadDanio;

        if (vidaTemporal < 0)
        {
            vidaActual = 0;
        }
        else
        {
            vidaActual = vidaTemporal;
        }

        cambioVida?.Invoke(vidaActual);

        if (vidaActual <= 0)
        {
            PerderVida();
        }
    }

    private void PerderVida()
    {
        vidasRestantes--;

        if (vidasRestantes > 0)
        {
            vidaActual = vidaMaxima;
            cambioVida?.Invoke(vidaActual);
            ReiniciarJugador();
        }
        else
        {
            FinDelJuego();
        }
    }

    private void ReiniciarJugador()
    {
        transform.position = posicionInicial;
        vidaActual = vidaMaxima;
        cambioVida?.Invoke(vidaActual);
    }

    private void FinDelJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reinicia el nivel
    }

    public int ObtenerVidasRestantes()
    {
        return vidasRestantes;
    }

    public void CurarVida(int cantidadCuracion)
    {
        int vidaTemporal = vidaActual + cantidadCuracion;

        if (vidaTemporal > vidaMaxima)
        {
            vidaActual = vidaMaxima;
        }
        else
        {
            vidaActual = vidaTemporal;
        }

        cambioVida?.Invoke(vidaActual);
    }
}
