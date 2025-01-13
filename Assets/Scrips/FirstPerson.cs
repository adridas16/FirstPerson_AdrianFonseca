using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{
    [Header("Deteccion del suelo")]
    [SerializeField] private Transform Pies;
    [SerializeField] private float radioDeteccion;
    [SerializeField] private LayerMask queEsSuelo;
    [Header("Controladores,Camara,animacion y movimiento")]
    [SerializeField] private float escalaGravedad;
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float altudaSalto;
    CharacterController Controller;
    private float velocidadRotacion;
    private Camera cam;
    private Animator anim;
    [SerializeField] private int vidas;
    [SerializeField] GameObject canMuerte;
    [SerializeField] GameObject canPause;




    //para poder modificar mi velocidad en caida libre y mi velocidad en los saltos
    private Vector3 MovimientoVertical;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
        Controller = GetComponent<CharacterController>();
        cam = Camera.main;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        muerte();
        Parar();
        float h = Input.GetAxisRaw("Horizontal"); //h=0, h=-1,h=1
        float v = Input.GetAxisRaw("Vertical");
        Vector2 input = new Vector2(h, v).normalized;

        transform.eulerAngles = new Vector3(0, cam.transform.eulerAngles.y, 0);

        if (input.sqrMagnitude > 0)
        {
            
            float anguloRotacion = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg+ cam.transform.eulerAngles.y;
            
            Vector3 movimiento = Quaternion.Euler(0, anguloRotacion, 0) * Vector3.forward;
            Controller.Move(movimiento* velocidadMovimiento*Time.deltaTime);
            anim.SetBool("walking", true);
            
        }
        else
        {
            anim.SetBool("walking", false);
        }
        AplicarGravedad();
        DeteccionSuelo();
    }
    private void AplicarGravedad()
    {
        //mi movimiento vertical en la y va aumentando a cierta escala por segundo
        MovimientoVertical.y += escalaGravedad * Time.deltaTime;
        Controller.Move(MovimientoVertical*Time.deltaTime);
    }
    private void DeteccionSuelo()
    {

        Collider[]collsDetectados = Physics.OverlapSphere(Pies.position, radioDeteccion, queEsSuelo);
        //Si existe un colider bajo mis pies
        if (collsDetectados.Length > 0)
        {
            MovimientoVertical.y = 0;
            Saltar();
        }

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("ParteEnemigo"))
        {
            Rigidbody rbEnemigo = hit.gameObject.GetComponent<Rigidbody>();
            Vector3 direccionFuerza = hit.transform.position - transform.position;
            rbEnemigo.AddForce(direccionFuerza.normalized * 50, ForceMode.Impulse);
        }
    }

    public void RecibirDanho(int danhoRecibido)
    {
        vidas -= danhoRecibido;
    }

    //sirve para dibujar figuras en la escena
    private void OnDrawGizmos()
    {
        Gizmos.color=Color.red;
        Gizmos.DrawSphere(Pies.position, radioDeteccion);
    }

    private void Saltar()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&Time.timeScale>0.1f)
        {
            MovimientoVertical.y = Mathf.Sqrt(-2 * escalaGravedad * altudaSalto);
        }
    }
    private void muerte()
    {
        if (vidas <= 0)
        {
            Cursor.visible = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            canMuerte.SetActive(true);
            
        }
    }
    private void Parar()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&&Time.timeScale>0.1f)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            canPause.SetActive(true);
            Time.timeScale = 0;
            
        }
    }
    

}
