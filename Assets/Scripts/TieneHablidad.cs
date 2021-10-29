using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TieneHablidad : MonoBehaviour
{
    public Habilidad habilidad;
    float cooldownTiempo;
    float activaTiempo;

    enum estadoHabilidad {
        lista,
        activa,
        cooldown
    }

    estadoHabilidad state = estadoHabilidad.lista;


    void Update()
    {
        switch (state)
        {
            case estadoHabilidad.lista:
                if(Input.GetKeyDown(KeyCode.F)){
                    habilidad.Activar(gameObject);
                    activaTiempo = habilidad.activo;
                    state = estadoHabilidad.activa;
            }
            break;
            case estadoHabilidad.activa:
                if(activaTiempo > 0){
                    activaTiempo -= Time.deltaTime;
                }
                else{
                    habilidad.Desactivar(gameObject);
                    state = estadoHabilidad.cooldown;
                    cooldownTiempo = habilidad.cooldown;
                }
            break;
            case estadoHabilidad.cooldown:
                if(cooldownTiempo > 0){
                    cooldownTiempo -= Time.deltaTime;
                }
                else{
                    state = estadoHabilidad.lista;
                }
            break;
        }
    }
}
