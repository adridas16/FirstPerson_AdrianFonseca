using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    
    [SerializeField] private float fuerzaDisparo;
    [SerializeField] private float TiempoVida;
    [SerializeField] private float radioExploosion;
    [SerializeField] private LayerMask queEsExplotable;
    [SerializeField] GameObject Explosion;
    // Start is called before the first frame update
    void Start()
    {
        
        GetComponent<Rigidbody>().AddForce(transform.forward.normalized * fuerzaDisparo, ForceMode.Impulse);
        Destroy(gameObject,TiempoVida);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        //toque suelo explosion
    }
    private void OnDestroy()
    {
        //instanciar una copia del prefab de explosion
        Instantiate(Explosion,transform.position, Quaternion.identity);
        Collider[] collsDetectados = Physics.OverlapSphere(transform.position,radioExploosion, queEsExplotable);
        if (collsDetectados.Length > 0)
        {
            foreach (Collider coll in collsDetectados) 
            {
                coll.GetComponent<ParteDeEnemigo>().Explotar();//desabilito el movimiento del enemigo impactado
                coll.GetComponent<Rigidbody>().isKinematic = false; //dejo los huesos en dinamico
                //por ultimo aplico explosion
                coll.GetComponent<Rigidbody>().AddExplosionForce(80,transform.position,radioExploosion,15f,ForceMode.Impulse);
               
            }
        }
    }
}
