using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class movPlayer : MonoBehaviour
{

    public Controls Controls;
    public Vector2 direccion;
    public Rigidbody2D  rb2D;
    public float velocidadMovimiento;
    public bool mirarDerecha = true;
    public float fuerzaSalto;
    public LayerMask queEsSuelo;
    public Transform controladorSuelo;
    public Vector3 dimencionesCaja;
    public bool enSuelo;



    private void Awake() {
        Controls = new();
    }
    private void OnEnable()
    {
        Controls.Enable();
        Controls.movimiento.salto.started += _ => Saltar();   
    }
    private void OnDisable() 
    {
        Controls.Disable();
        Controls.movimiento.salto.started -= _ => Saltar();   
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direccion = Controls.movimiento.mover.ReadValue<Vector2>();
        AjustarRotacion(direccion.x);
        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimencionesCaja,0f,queEsSuelo);
    }

    private void FixedUpdate()  
    {
        rb2D.velocity = new Vector2(direccion.x*velocidadMovimiento, rb2D.velocity.y);
    }

    private void AjustarRotacion(float direccionX)
    {
        if (direccionX > 0 && !mirarDerecha)
        {
            Girar();
        }
        else if (direccionX < 0 && mirarDerecha)
        {
            Girar();
        }
    }

    private void Girar()
    {
        mirarDerecha = !mirarDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale= escala;
    }

    private void Saltar()
    {
        if (enSuelo)
        {
            rb2D.AddForce(new Vector2(0,fuerzaSalto), ForceMode2D.Impulse);
        }
        
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(controladorSuelo.position, dimencionesCaja);
    }
}
