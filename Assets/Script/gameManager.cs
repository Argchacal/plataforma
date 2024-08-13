using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    //esto es una propiedad solo de lectura para poder leer los puntos de otro scrip
    public int PuntosTotales { get;{ return puntosTotales }}
    // 
    private int puntosTotales;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddPunto()
    {
        puntosTotales= puntosTotales + puntosASumar;
        Debug.log(puntosTotales );
    }
}
