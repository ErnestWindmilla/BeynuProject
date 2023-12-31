using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;
using System.Dynamic;
public class ARInteractionsManager : MonoBehaviour
{

    [SerializeField] public Camera aRCamera;
     [SerializeField] public Textos infoUpdate;
  
    [SerializeField] public PasandoInfo pases;
    private ARRaycastManager aRRaycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>(); 
    private bool isInitialPosition;
    private bool isOverUI;
    private bool isOver3DModel;
    private Vector2 initialTouchPos;


    private string itemMenuDescription;
    private GameObject aRPointer;
    
    private GameObject item3DModel;
    public GameObject Item3DModel
    {
        set{
            item3DModel = value;
            item3DModel.transform.position = aRPointer.transform.position;
            item3DModel.transform.parent = aRPointer.transform;
            isInitialPosition = true;
        }
    } 
    public string ItemMenuDescription
    {
        set{
            itemMenuDescription=value;
        }
        get{
            return itemMenuDescription;
        }
    }


    void Start()
    {
        aRPointer = transform.GetChild(0).gameObject;
        aRRaycastManager = FindObjectOfType<ARRaycastManager>(); 
        GameManager.instance.OnMainMenu += setItemPosition;

    }

    void Update()
    {
                 
        if(isInitialPosition)
        {
            Vector2 middlePointScreen = new Vector2(Screen.width/2, Screen.height/2);
            aRRaycastManager.Raycast(middlePointScreen, hits, TrackableType.Planes);
            if(hits.Count>0)
            {
                transform.position = hits[0].pose.position;
                transform.rotation = hits[0].pose.rotation;
                aRPointer.SetActive(true);
                isInitialPosition=false;
            }
        }
        if(Input.touchCount>0)
        {
            Touch touchOne = Input.GetTouch(0);
            if(touchOne.phase == TouchPhase.Began)
            {
                var touchPosition = touchOne.position;
                isOverUI = isTapOverUI(touchPosition);
            }

            if(touchOne.phase == TouchPhase.Moved)
            {
                if(aRRaycastManager.Raycast(touchOne.position, hits, TrackableType.Planes))
                {
                    Pose hitPose = hits[0].pose;
                    if(!isOverUI)
                    {
                       transform.position = hitPose.position; 
                    }
                }
            }

            if(Input.touchCount ==2)
            {
                Touch touchTwo = Input.GetTouch(1);
               
                if(touchOne.phase == TouchPhase.Began || touchTwo.phase == TouchPhase.Began)
                {
                    initialTouchPos = touchTwo.position - touchOne.position;
                }

                if(touchOne.phase == TouchPhase.Moved || touchTwo.phase == TouchPhase.Moved)
                {
                    Vector2 currentTouchPos = touchTwo.position - touchOne.position;
                    float angle = Vector2.SignedAngle(initialTouchPos, currentTouchPos);
                    item3DModel.transform.rotation = Quaternion.Euler(0, item3DModel.transform.eulerAngles.y - angle ,0);
                    initialTouchPos = currentTouchPos;
                }
            }
        }
    }

    private bool isTapOverUI(Vector2 touchPosition)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(touchPosition.x, touchPosition.y);
        List<RaycastResult> result = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, result);
        return result.Count>0;
    }

    private void setItemPosition()
    {
        if(item3DModel != null)
        {
            item3DModel.transform.parent = null;
            aRPointer.SetActive(false);
            item3DModel = null;
        }
    }

    public void DeleteItem()
    {
        Destroy(item3DModel);
        aRPointer.SetActive(false);
        GameManager.instance.MainMenu();
    }
}

