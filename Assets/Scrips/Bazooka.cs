using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazooka : MonoBehaviour
{
    [SerializeField] private Transform SpawnPoint;
    [SerializeField] GameObject Granade;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //creo una instancia con la misma orientacion que el cañon
            Instantiate(Granade, SpawnPoint.position,SpawnPoint.rotation);

            
        }
    }
           
}
