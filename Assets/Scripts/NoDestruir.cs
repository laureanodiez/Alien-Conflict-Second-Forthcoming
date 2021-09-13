using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoDestruir : MonoBehaviour
{
    public static NoDestruir instance; //la idea de esto es hacer que haya
    // una UNICA instancia de este objeto, y no destruirla nunca cambiando de escena
    // pero destruyendo todos sus duplicados
    private void Start() {
        if(instance != null){
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
    
}
