using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PasandoInfo : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TMPro.TMP_Text menuDescription;

    public void actualizar(Textos cosa){
        menuDescription.text=cosa.Texto;
    }

    
    // Update is called once per frame
    // void Update(){

    // }

    // void Awake(){
    //     menuDescription.text = infoUpdate.Texto;
    //     Debug.Log(infoUpdate.Texto);
    // }
    
}
