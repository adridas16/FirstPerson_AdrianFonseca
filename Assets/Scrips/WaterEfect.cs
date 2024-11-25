using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class WaterEfect : MonoBehaviour
{
    private Volume efecto;
    [SerializeField] private float velocidad;
    // Start is called before the first frame update
    void Start()
    {
        efecto = GetComponent<Volume>();
    }

    // Update is called once per frame
    void Update()
    {
        //Delta time =tiempo entre dos frames consecutivos
        //Time.time =tiempo de juego total.
       
        //Busca en tu profile si tienes el efecto LensDistorsion
        if(efecto.profile.TryGet(out LensDistortion distorsion))
        {
            FloatParameter xValue = new FloatParameter(1+Mathf.Cos(velocidad * Time.time)/2);
            FloatParameter yValue = new FloatParameter(1+Mathf.Sin(velocidad * Time.time)/2);
            distorsion.xMultiplier.SetValue(xValue);
            distorsion.yMultiplier.SetValue(yValue);
        }
    }
}
