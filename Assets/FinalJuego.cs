using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalJuego : MonoBehaviour
{
    [SerializeField] GameObject CanvasFin;
    Coleccionables coleccionables;
    

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            
            CanvasFin.SetActive(true);
            
            


        }
    }

}
