using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorLlave : MonoBehaviour
{
    public GameObject puerta;
    public GameObject llave;
    

    void OnCollisionEnter(Collision collision) {
        Destroy(llave);
        Destroy(puerta);
    }


}
