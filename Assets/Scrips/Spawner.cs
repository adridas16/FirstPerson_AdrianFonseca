using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] puntosSpawn;
    [SerializeField] private Enemigo enemigoprefab;
     // Start is called before the first frame update
    void Start()
    {
        //saca una copia de un enemigo en el punto 0 con rotacion0,0,0.
        Instantiate(enemigoprefab, puntosSpawn[0].position, Quaternion.identity);
    }
   
   

}
