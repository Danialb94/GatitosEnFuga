using UnityEngine;

public class MovimientoGatitos : MonoBehaviour
{
    public Transform terremoto;           // Referencia al transform del personaje principal
    public float detectionRadius = 5f; // Radio de detecci�n para asustarse
    public float fleeDistance = 10f;   // Distancia a la que huir� el NPC
    public float fleeSpeed = 0.2f;      //Velocidad en la que huye el NPC
   
    private Rigidbody2D rb;
    private bool isFleeing = true;    //Estado de huida
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetFloat("velocidad", fleeSpeed);
        if (isFleeing)
        {
            if (terremoto != null)
            {
                // Calcular la distancia al jugador
                float distanceToterremoto = Vector2.Distance(terremoto.position, transform.position);

                // Si el jugador est� dentro del radio de detecci�n
                if (distanceToterremoto <= detectionRadius)
                {
                    // Calcular la direcci�n opuesta al jugador
                    Vector2 fleeDirection = (transform.position - terremoto.position).normalized;
                    Vector2 newGoal = (Vector2)transform.position + fleeDirection * fleeDistance;

                    // Mover al NPC en la direcci�n opuesta
                    rb.MovePosition(newGoal);
                }

            }
        }
    }
    // M�todo para dibujar el radio de detecci�n en la vista de escena
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
