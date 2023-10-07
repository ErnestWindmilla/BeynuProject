using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; //Linea escrita
public class GameManager : MonoBehaviour
{
    public event Action OnMainMenu; //Aqui se refiere al evento de estar en el menu principal
    public event Action OnItemsMenu;//Se refirere al evento de estar en el menu de items (platillos)
    public event Action OnARPosition;

    public static GameManager instance;

//Al usar el siguiente metodo, se asegura que solo se usa una sola instancia del GameManager
    private void Awake () {
        if(instance != null || instance != this )
        {
            Destroy(gameObject);
        } else {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        MainMenu();
    }

    public void MainMenu () {
        OnMainMenu?.Invoke(); //El simbolo de interrogacion hace referencia que algo esta inscrito al evento
        Debug.Log("Main Menu Activated");

    }

    public void ItemsMenu () {
        OnItemsMenu?.Invoke();
        Debug.Log("Items Menu Activated");
    }

    public void ARPosition () {
        OnARPosition?.Invoke();
        Debug.Log("ARPosition Activated");
    }
    //Done by Ernesto Molina October 6 2023
}
