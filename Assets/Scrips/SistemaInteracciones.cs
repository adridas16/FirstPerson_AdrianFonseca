using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class SistemaInteracciones : MonoBehaviour
{
    private Camera cam;
    [SerializeField]float DistacioaInteraccion;
    private Transform InteractuableActual;
    // Start is called before the first frame update
    void Start()
    {
        cam=Camera.main;
      
    }
        
    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit ObjectHitInfo, DistacioaInteraccion))
        {
            if (ObjectHitInfo.transform.CompareTag("CajaBalas"))
            {
                Debug.Log("La caja La caja");

                InteractuableActual= ObjectHitInfo.transform;
                InteractuableActual.GetComponent<Outline>().enabled = true;
            }
            

            
        } 
       else if(InteractuableActual)
       {
          InteractuableActual.GetComponent<Outline>().enabled = false;
          InteractuableActual = null; 
       }
    }
   
}
