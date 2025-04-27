//Potrebbe essere pi� semplice, ma per non toccare le impostazioni gloabali del progetto mi complico la vita :)
//Se vedete che trapassa il pianeta � un bug che conosco, ma per risolverlo devo toccare le impostazioni globali del progetto

using UnityEngine;
using UnityEngine.Events;

public class RigidbodyCustom : MonoBehaviour
{
    //Variabili che teoricamente andrebbero su un altro script (unico in tutta la scena)
    //Solo per fare prima ...
    private float maxVelocity = 1f;

    //Component
    private GravityPlanet[] gravityPlanet;

    //Variabili specifiche
    [Tooltip("Se pubblica NON MODIFICARE")]
    private Vector3 gravityCustom = Vector3.zero;   //Mettere pubblica per vederne i valori
    [Tooltip("Se pubblica NON MODIFICARE")]
    private Vector3 velocity = Vector3.zero;   //Mettere pubblica per vederne i valori
    private RaycastHit hit;
    private Vector3 deltaCalcPosition = Vector3.zero;

    //Variabili per ottimizzazione (controllare la gravit� 5 volte al secondo mi sembra pi� che sufficiente)
    private byte frameLost = 10;
    private byte contFrameLost = 0;

    //Variabili per debug
    [Header("Debug")]
    public bool debug = false;

    //Variabili per altri script
    [Header("Eventi")]
    public UnityEvent<bool> ground = new UnityEvent<bool>();
    [HideInInspector]
    public bool isGrounded;

    void Start()
    {
        //Trovo tutti i pianeti della scena
        gravityPlanet = FindObjectsOfType<GravityPlanet>();

        //Controllo la gravit� personalizzata
        Gravity();
        GravityCalc();
    }

    //Calcolo la gravit�
    private void GravityCalc()
    {
        //Resetto
        gravityCustom = Vector3.zero;

        //Gravit� calcolata tenendo condo di pianeti multipli in scena
        foreach (GravityPlanet gP in gravityPlanet)
        {
            //gravit� = direzione * gravit� pianeta * tempo
            gravityCustom += (transform.position - gP.transform.position).normalized * -gP.gravityPlanet * Time.fixedDeltaTime * frameLost;
        }

        //Mi calcolo un margine da usare (tutta esperienza qua)
        deltaCalcPosition = gravityCustom * 0.1f;

        //Determino la sua velocit� iniziale
        if (velocity == Vector3.zero)
        {
            //Controllo cosa sta toccando
            if (Physics.Linecast(transform.position - deltaCalcPosition, transform.position + gravityCustom, out hit))
            {
                //Non sa cosa tocca
                if (hit.collider.GetComponent<GravityPlanet>() == null)
                {
                    //Tocca qualcosa che non � un pianeta, perci� in volo
                    InizializzaInVolo();
                }
            }
            else
            {
                //Se sa di essere in volo
                InizializzaInVolo();
            }
        }
    }

    private void InizializzaInVolo()
    {
        velocity = gravityCustom;
        isGrounded = false;
        ground.Invoke(isGrounded);
        if (debug)
            Debug.Log("Tocca un pianeta: " + isGrounded);
    }

    //Applico la gravit�
    private void Gravity()
    {
        //Controllo cosa sta toccando
        if (Physics.Linecast(transform.position - deltaCalcPosition, transform.position + velocity, out hit))
        {
            //Non sa cosa tocca
            if (hit.collider.GetComponent<GravityPlanet>() == null)
            {
                //Tocca qualcosa che non � un pianeta, perci� in volo
                InVolo();
            }
            else
            {
                //� su un pianeta
                transform.position = hit.point;
                velocity = Vector3.zero;
                isGrounded = true;
                ground.Invoke(isGrounded);
                if (debug)
                    Debug.Log("Tocca un pianeta: " + isGrounded);
            }
        }
        else
        {
            //In volo
            InVolo();
        }
    }

    //Cose da fare quando in volo
    private void InVolo()
    {
        //Sposto l'oggetto
        transform.Translate(velocity);
        velocity += gravityCustom;

        //Blocco la sua velocit� massima per evitare che Unity esploda
        if (velocity.magnitude > maxVelocity)
        {
            //Calcolo arbitrario per mantenere la velocit�, ma una direzione diversa
            velocity += gravityCustom;
            velocity = velocity.normalized * maxVelocity;
        }
    }

    void FixedUpdate()
    {
        contFrameLost++;

        if (debug)
        {
            Debug.Log("Velocit� asteroide: " + velocity.magnitude);
        }

        //Ottimizzo i calcoli
        if (contFrameLost == frameLost)
        {
            contFrameLost = 0;
            GravityCalc();
        }

        //Ottimizzo i calcoli, se fermo controllo la gravit� ogni tot, se in movimento ogni fixedUpdate
        if ((velocity == Vector3.zero && contFrameLost == frameLost) || velocity != Vector3.zero)
        {
            Gravity();
        }
    }
}
