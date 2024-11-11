using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParteDeEnemigo : MonoBehaviour
{
    [SerializeField] private Enemigo mainScript;
    [SerializeField] private float multiplicadorDanho;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RecibirDanho(float danhorecibido)
    {
        mainScript.Vidas -= (danhorecibido*multiplicadorDanho);
        if (mainScript.Vidas <= 0)
        {
            mainScript.Morir();
        }
    }
}
