using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private GameObject itemsMenuCanvas;
    [SerializeField] private GameObject ARPositionCanvas;

    private float animationDuration = 0.3f;

    void Start()
    {
        GameManager.instance.OnMainMenu += ActivateMainMenu;
        GameManager.instance.OnItemsMenu += ActivateItemsMenu;
        GameManager.instance.OnARPosition += ActivateARPosition;
    }

    private void ActivateMainMenu()
    {
        TweenCanvas(mainMenuCanvas, Vector3.one, animationDuration);
        TweenCanvas(itemsMenuCanvas, Vector3.zero, animationDuration);
        TweenCanvas(ARPositionCanvas, Vector3.zero, animationDuration);
    }

    private void ActivateItemsMenu()
    {
        TweenCanvas(mainMenuCanvas, Vector3.zero, animationDuration);
        TweenCanvas(itemsMenuCanvas, Vector3.one, animationDuration);
        TweenCanvas(ARPositionCanvas, Vector3.zero, animationDuration);
        itemsMenuCanvas.transform.GetChild(1).transform.DOMoveY(300, animationDuration);
    }

    private void ActivateARPosition()
    {
        TweenCanvas(mainMenuCanvas, Vector3.zero, animationDuration);
        TweenCanvas(itemsMenuCanvas, Vector3.zero, animationDuration);
        TweenCanvas(ARPositionCanvas, Vector3.one, animationDuration);
    }

    private void TweenCanvas(GameObject canvas, Vector3 scale, float duration)
    {
        foreach (Transform child in canvas.transform)
        {
            child.DOScale(scale, duration);
        }
    }
}
