using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeapoHolder : MonoBehaviour
{
    [SerializeField] GameObject[] weapons;
    private int indicearmaActual=1;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
       
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CambioArma(0);
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CambioArma(1);

        } 
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CambioArma(2);

        }

    }
    void CambioArma(int nuevoArma)
    {
        //desactivo el amra que actualmente llevo equipada
        weapons[indicearmaActual].SetActive(false);

        //despues, cambio el indice
        indicearmaActual = nuevoArma;

        weapons[indicearmaActual].SetActive(true);
    }
    
    
}
