using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class WaterEfect : MonoBehaviour
{
    private Volume efecto;
    // Start is called before the first frame update
    void Start()
    {
        efecto = GetComponent<Volume>();
    }

    // Update is called once per frame
    void Update()
    {
        //Busca en tu profile si tienes el efecto LensDistorsion
        if(efecto.profile.TryGet(out LensDistortion distorsion))
        {
            //distorsion.xMultiplier
        }
    }
}
