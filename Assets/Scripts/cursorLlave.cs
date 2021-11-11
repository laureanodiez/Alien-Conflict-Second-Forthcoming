using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorLlave : MonoBehaviour
{
    public GameObject puerta;
    public GameObject llave;
    public GameObject player;
    
    private void Start() {

    }

    /*void OnCollisionEnter(Collision collision) {
        Destroy(llave);
        Destroy(puerta);
    }*/

    void OnCollisionEnter(Collision collision)
    {
        Destroy(llave);
        Destroy(puerta);
    }


}
