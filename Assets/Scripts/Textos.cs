using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu]
public class Textos : ScriptableObject
{
    public string Texto;
    
    public void actualizarInfo(string textito){
        Texto = textito;
        Debug.Log(Texto);
        
    }

    
}
