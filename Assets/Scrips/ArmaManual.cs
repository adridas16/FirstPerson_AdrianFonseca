using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class ArmaManual : MonoBehaviour
{
    [SerializeField] private ParticleSystem system;
    [SerializeField] private ArmaSo misDatos;
    private Camera cam;
   
    // Start is called before the first frame update
    void Start()
    {
       
        cam=Camera.main;
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            system.Play();
            Debug.Log("pium");
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitinfo, misDatos.distanciaAtaque))
            {
                if (hitinfo.transform.CompareTag("ParteEnemigo"))
                {
                    Debug.Log(hitinfo.transform.name);
                    hitinfo.transform.GetComponent<ParteDeEnemigo>().RecibirDanho(misDatos.danhoAtaque);
                }
               
            }
        }
        
    }
    
}
