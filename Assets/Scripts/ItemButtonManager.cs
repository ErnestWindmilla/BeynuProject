using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemButtonManager : MonoBehaviour
{
    private string itemName;
    private string itemDescription;
    private Sprite itemImage;
    private GameObject item3DModel;

    private ARInteractionsManager interactionsManager;

    public string ItemName { set => itemName = value; }
    public string ItemDescription { set => itemDescription = value; }
    public Sprite ItemImage { set => itemImage = value; }
    public GameObject Item3DModel { set => item3DModel = value; }

    void Start()
    {
        Transform childTransform = transform.GetChild(0);
        childTransform.GetComponent<TMP_Text>().text = itemName;

        childTransform = transform.GetChild(1);
        childTransform.GetComponent<RawImage>().texture = itemImage.texture;

        childTransform = transform.GetChild(2);
        childTransform.GetComponent<TMP_Text>().text = itemDescription;

        var button = GetComponent<Button>();
        button.onClick.AddListener(GameManager.instance.ARPosition);
        button.onClick.AddListener(Create3DModel);

        interactionsManager = FindObjectOfType<ARInteractionsManager>();
    }

    private void Create3DModel()
    {
        interactionsManager.Item3DModel = Instantiate(item3DModel);
    }
}
