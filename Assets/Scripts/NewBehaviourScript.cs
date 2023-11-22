using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
 private void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus)
        {
            // Verifica si la aplicación fue abierta desde un enlace personalizado
            string url = GetUrlScheme();
            if (!string.IsNullOrEmpty(url))
            {
                // Maneja la apertura de la aplicación aquí
                Debug.Log("La aplicación fue abierta desde el enlace: " + url);
            }
        }
    }

    private string GetUrlScheme()
    {
        // Obtiene el enlace personalizado desde el argumento de línea de comandos
        string[] args = System.Environment.GetCommandLineArgs();
        for (int i = 0; i < args.Length; i++)
        {
            if (args[i].StartsWith("miapp://"))
            {
                return args[i];
            }
        }
        return null;
    }
}
