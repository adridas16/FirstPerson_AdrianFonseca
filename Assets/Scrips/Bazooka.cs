using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bazooka : MonoBehaviour
{
    [SerializeField] private Transform SpawnPoint;
    [SerializeField] GameObject Granade;
    [SerializeField] int granadas;
    [SerializeField] private Animator anim;
    private bool preparado=false;
    [SerializeField] TMP_Text granadasText;
    // Start is called before the first frame update

    void Start()
    {
        preparado=false;
    }

    // Update is called once per frame
    void Update()
    {
        granadasText.SetText("granadas: " + granadas);
        if (preparado)
        {
            if (granadas >= 1)
            {
                anim.SetBool("Recargar", false);
                if (Input.GetMouseButtonDown(0))
                {
                    granadas--;
                    //creo una instancia con la misma orientacion que el cañon
                    Instantiate(Granade, SpawnPoint.position, SpawnPoint.rotation);


                }
            }
            else
            {
                anim.SetBool("Recargar", true);
                preparado = false;
            }
        } 
    }
    public void Recargar()
    {
        granadas = 3;
        preparado = true;
    }
    public void Preparado()
    {
        preparado = true;
    }

}
