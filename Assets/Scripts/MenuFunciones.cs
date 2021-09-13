using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuFunciones : MonoBehaviour
{
    public void cargarEscenaPrueba(string nivel){
        SceneManager.LoadScene(nivel);
    }
}
