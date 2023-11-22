using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handler : MonoBehaviour
{
    void Start()
    {
        // Manejar el deep link al inicio de la aplicación
        HandleDeepLink("beynu://app");
    }

    public void HandleDeepLink(string deepLink)
    {
        // Aquí puedes implementar la lógica para manejar el deep link en Unity
        Debug.Log("Deep Link recibido en Unity: " + deepLink);

        // Puedes realizar acciones específicas en Unity basándote en el deep link recibido
        // Por ejemplo, cargar una escena específica, mostrar contenido relacionado, etc.
    }
}
