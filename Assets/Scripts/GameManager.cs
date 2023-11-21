using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 
public class GameManager : MonoBehaviour
{
    public event Action OnMainMenu; 
    public event Action OnItemsMenu;
    public event Action OnARPosition;

    public static GameManager instance;

    private void Awake () 
    {
        if(instance != null || instance != this )
        {
            instance = this;
        } 
        else 
        {
            
            Destroy(gameObject);
        }
    }

    void Start()
    {
        MainMenu();//
    }

    public void MainMenu () 
    {
        OnMainMenu?.Invoke(); 
        Debug.Log("Main Menu Activated");
    }

    public void ItemsMenu () 
    {
        OnItemsMenu?.Invoke();
        Debug.Log("Items Menu Activated");
    }

    public void ARPosition () 
    {
        OnARPosition?.Invoke();
        Debug.Log("ARPosition Activated");
    }

    public void CloseApp() 
    { 
        Application.Quit();
    }
}
