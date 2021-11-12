using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SriptableObjectsChanger : MonoBehaviour
{
    
    [Header ("Scriptable Objects")]
    [SerializeField] private ScriptableObject[] scriptableObjects;   

    [Header("Display Scripts")]
    [SerializeField] private DisplayArma gunDisplay;
    
    private int currentIndex;       
    private void Awake()
    {
        ChangeScriptableObject(0);
    }
    public void ChangeScriptableObject(int _change)
    {
        currentIndex += _change;
        if (currentIndex < 0) currentIndex = scriptableObjects.Length - 1;
        else if (currentIndex > scriptableObjects.Length - 1) currentIndex = 0;     
        if(gunDisplay != null) gunDisplay.DisplayGun((Arma)scriptableObjects[currentIndex]);
    }
    
}
