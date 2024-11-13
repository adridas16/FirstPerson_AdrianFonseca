using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjemploCorrutinas : MonoBehaviour
{
    private bool Corrutinas;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)&&Corrutinas==false)
        {
            StartCoroutine(Semaforo());
            Corrutinas = true;
        }
        
    }
     IEnumerator Semaforo()
    {
        while (true)
        {
            Debug.Log("Verde");
            yield return new WaitForSeconds(2); ;
            Debug.Log("Amarillo");
            yield return new WaitForSeconds(3);
            Debug.Log("Rojo");
        }
        
    }
}
