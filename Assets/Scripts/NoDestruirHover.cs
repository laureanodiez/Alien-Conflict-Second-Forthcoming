using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoDestruirHover : MonoBehaviour
{
    public static NoDestruirHover Instance; //la idea de esto es hacer que haya
    // una UNICA instancia de este objeto, y no destruirla nunca cambiando de escena
    // pero destruyendo todos sus duplicados
    private void Start() {
        if(Instance != null){
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
    
}
