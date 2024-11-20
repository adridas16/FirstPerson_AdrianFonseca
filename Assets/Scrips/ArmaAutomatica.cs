using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class ArmaAutomatica : MonoBehaviour
{
    [SerializeField] private ParticleSystem system;
    [SerializeField] private ArmaSo misDatos;
    private Camera cam;
    [SerializeField] private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
       
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetMouseButton(0)&&timer>misDatos.cadenciaAtaque)
        {
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
}
