using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneda : MonoBehaviour
{
    public int valor = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collosion)
    {
        if(collosion.CompareTag("Player"))
        {
            gameManager.AddPunto(valor);
            //destruye el objeto que tiene este script
            Destroy(this.gameObject);
        }
    }
}
