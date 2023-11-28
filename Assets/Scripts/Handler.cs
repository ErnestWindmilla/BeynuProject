using UnityEngine;

public class Handler : MonoBehaviour
{
    void Start()
    {
        HandleDeepLink("beynu://main");
    }

    public void HandleDeepLink(string deepLink)
    {
        Debug.Log("Deep Link recibido en Unity: " + deepLink);
    }
}
