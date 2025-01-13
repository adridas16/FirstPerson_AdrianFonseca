using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coleccionables : MonoBehaviour
{
    static int coleccionable;
    private bool finalJ;
    public static int Coleccionable { get => coleccionable; set => coleccionable = value; }
    [SerializeField] GameObject finalJuego;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ColeccionableP()
    {
        coleccionable++;
        if (coleccionable == 5)
        {
            finalJ = true;
            Debug.Log(finalJ);
            finalJuego.SetActive(true);
        }
        Debug.Log(coleccionable);
        Destroy(this.gameObject);
       
    }

}
