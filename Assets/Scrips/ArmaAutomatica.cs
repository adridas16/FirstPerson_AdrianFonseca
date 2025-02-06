using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class ArmaAutomatica : MonoBehaviour
{
    [SerializeField] private ParticleSystem system;
    [SerializeField] private ArmaSo misDatos;
    private Camera cam;
    [SerializeField] private float timer = 0;
    Animator anim;
    [SerializeField] int balas;
    [SerializeField] TMP_Text balastext;
    private bool preparado;
    
    // Start is called before the first frame update
    private void Awake()
    {
        anim = GetComponent<Animator>();
        balas = misDatos.balasCargador;
    }
    void Start()
    {
        cam = Camera.main;
        balas = misDatos.balasCargador;
    }

    // Update is called once per frame
    void Update()
    {
        balastext.SetText("balas: " + balas);

        timer += Time.deltaTime;
        if (preparado)
        {
            if (balas > 0)
            {
                anim.SetBool("Recargar", false);
                if (Input.GetMouseButton(0) && timer > misDatos.cadenciaAtaque)
                {
                    balas --;
                    system.Play();
                    Debug.Log("pium");
                    timer = 0f;
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
            else
            {
                anim.SetBool("Recargar", true);

            }
        }
       
        
    }
    public void Recargar() 
    {
        balas = 60;
    }
    public void Preparado()
    {
        preparado = true;
    }
}
