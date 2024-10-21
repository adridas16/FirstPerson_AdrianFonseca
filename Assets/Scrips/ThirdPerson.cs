using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ThirdPerson : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    CharacterController Controller;
    [SerializeField] private float smothing;
    private Camera cam;
    private float velocidadRotacion;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Controller = GetComponent<CharacterController>();
        cam = Camera.main;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal"); //h=0, h=-1,h=1
        float v = Input.GetAxisRaw("Vertical");
        Vector2 input = new Vector2(h, v).normalized;


        if (input.sqrMagnitude > 0)
        {

            float anguloRotacion = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
            float anguloSuave = Mathf.SmoothDampAngle(transform.eulerAngles.y, anguloRotacion,ref velocidadRotacion,  0.3f);
            transform.eulerAngles = new Vector3(0, anguloSuave, 0);
            Vector3 movimiento = Quaternion.Euler(0, anguloRotacion, 0) * Vector3.forward;
            Controller.Move(movimiento * velocidadMovimiento * Time.deltaTime);

             anim.SetBool("walking",true);

        }
        else
        {
            anim.SetBool("walking", false);
        }
    }
}
