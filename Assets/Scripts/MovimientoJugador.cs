using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    private Rigidbody2D rb2D;

    // Movimiento
    private float movimientoHorizontal;
    [SerializeField] private float velocidadDeMovimiento = 400;
    [Range(0, 0.3f)][SerializeField] private float suavizadoDeMovimiento = 0.1f;
    private Vector3 velocidad = Vector3.zero;
    private bool mirandoDerecha = true;
    private Animator anim;
    public event EventHandler OnJump;

    // Salto
    [SerializeField] private float fuerzaDeSalto = 400;
    [SerializeField] private LayerMask queEsSuelo;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private Vector3 dimensionesCaja;
    private bool enSuelo;
    private bool salto = false;
    private int maxSaltos = 2;
    private int saltosRestantes;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        saltosRestantes = maxSaltos;
    }

    private void Update()
    {
        anim.SetFloat("velocidad", Mathf.Abs(movimientoHorizontal));
        anim.SetBool("piso", enSuelo);

        movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadDeMovimiento;

        // Se permite saltar si está en el suelo o si quedan saltos restantes
        if ((Input.GetButtonDown("Jump") && enSuelo))
        {
            salto = true;
            saltosRestantes--; // Decrementa los saltos restantes cuando se realiza un salto
            OnJump?.Invoke(this, EventArgs.Empty);
            Debug.Log(saltosRestantes);
        }
        else if (Input.GetButtonDown("Jump") && (enSuelo == false) && saltosRestantes >= 2)
        {
            salto = true;
            saltosRestantes--;
            OnJump?.Invoke(this, EventArgs.Empty);
            Debug.Log(saltosRestantes);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "corazones")
        {
            col.SendMessage("ParticulasInicia");
        }
    }

    private void FixedUpdate()
    {
        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, queEsSuelo);
        Debug.Log(enSuelo);
        if (enSuelo)
        {
            saltosRestantes = maxSaltos; // Restaura los saltos restantes cuando toca el suelo
        }

        // Mover
        Mover(movimientoHorizontal * Time.fixedDeltaTime, salto);
        salto = false;
    }

    private void Mover(float mover, bool saltar)
    {
        Vector3 velocidadObjetivo = new Vector2(mover, rb2D.velocity.y);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocidadObjetivo, ref velocidad, suavizadoDeMovimiento);

        if (mover > 0 && !mirandoDerecha)
        {
            Girar();
        }
        else if (mover < 0 && mirandoDerecha)
        {
            Girar();
        }

        if (saltar)
        {
            rb2D.AddForce(new Vector2(0f, fuerzaDeSalto));
        }
    }

    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCaja);
    }
}
