using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public class SistemaInteracciones : MonoBehaviour
{
    private Camera cam;
    [SerializeField]float DistacioaInteraccion;
    private Transform InteractuableActual;
    [SerializeField] GameObject marco;
    [SerializeField] TMP_Text npcText;
    [SerializeField] Transform Player;
   
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
            if (ObjectHitInfo.transform.TryGetComponent(out CajaMunicion scripCaja))
            {
                Debug.Log("La caja La caja");

                InteractuableActual = ObjectHitInfo.transform;
                InteractuableActual.GetComponent<Outline>().enabled = true;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    scripCaja.Abrir();
                }

            }
            else if(ObjectHitInfo.transform.TryGetComponent(out Coleccionables coleccionable)&& Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("La cinta La cinta");

                InteractuableActual = ObjectHitInfo.transform;
                InteractuableActual.GetComponent<Outline>().enabled = true;
                coleccionable.ColeccionableP();
                
            }
            else if (InteractuableActual)
            {
                InteractuableActual.GetComponent<Outline>().enabled = false;
                InteractuableActual = null;
                
            }
             if (ObjectHitInfo.transform.CompareTag("Npc") && Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("texto");
                marco.SetActive(true);


            }
             else if (!ObjectHitInfo.transform.CompareTag("Npc"))
            {
                marco.SetActive(false);
            }

            
        }
    }
    
}
