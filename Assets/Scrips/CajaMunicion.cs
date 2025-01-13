using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaMunicion : MonoBehaviour
{
    private Animator anim;
    private Collider colider;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        colider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void Abrir()
    {
        anim.SetTrigger("abrir");
        colider.enabled = false;

    }
}
