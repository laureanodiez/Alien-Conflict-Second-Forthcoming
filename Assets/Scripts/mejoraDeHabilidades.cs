using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mejoraDeHabilidades : MonoBehaviour
{
    public GameObject player;
    public GameObject tienda;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) < 3.0f) {
            Debug.Log("Hola");
            if(Input.GetKeyDown(KeyCode.E)) {
                tienda.SetActive(true);           
            }
        }
    }
}