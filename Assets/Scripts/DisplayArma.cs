using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayArma : MonoBehaviour
{
    [Header ("Nombre Arma")]
    [SerializeField] private Text nombreArma;

    /*[Header("Gun Stats")]
    [SerializeField] private Transform damageStars;
    [SerializeField] private Transform accuracyStars;
    [SerializeField] private Transform rangeStars;
    [SerializeField] private Transform fireRateStars;
    */

    [Header("Holder de arma")]
    [SerializeField] private Transform armaHolder;

    public void DisplayGun(Arma _Arma)
    {
        nombreArma.text = _Arma.nombre;

        //Damage
        /*for (int i = 0; i < damageStars.childCount; i++)
            damageStars.GetChild(i).gameObject.SetActive(i < _gun.damage);

        //Accuracy
        for (int i = 0; i < accuracyStars.childCount; i++)
            accuracyStars.GetChild(i).gameObject.SetActive(i < _gun.accuracy);

        //Range
        for (int i = 0; i < rangeStars.childCount; i++)
            rangeStars.GetChild(i).gameObject.SetActive(i < _gun.range);

        //Fire Rate
        for (int i = 0; i < fireRateStars.childCount; i++)
            fireRateStars.GetChild(i).gameObject.SetActive(i < _gun.fireRate);
*/
        if (armaHolder.childCount > 0)
            Destroy(armaHolder.GetChild(0).gameObject);
        
        Instantiate(_Arma.modeloArma, armaHolder.position, armaHolder.rotation, armaHolder);
    }
}
