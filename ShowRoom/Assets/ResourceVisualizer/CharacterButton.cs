using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterButton : MonoBehaviour
{

    public Button buttonComponent;
    public Text nameLabel;
    public Image iconImage;


    private CharacterButtonInfo item;
    private CharacterScrollList scrollList;

    // Use this for initialization
    void Start()
    {
        buttonComponent.onClick.AddListener(HandleClick);
    }

    public void Setup(CharacterButtonInfo buttonInfo, CharacterScrollList currentScrollList)
    {
        item = buttonInfo;
        nameLabel.text = item.Name;
        // iconImage.sprite = item.icon;
        // priceText.text = item.price.ToString();
        scrollList = currentScrollList;

    }

    public void HandleClick()
    {
        scrollList.AddCharacterToScene(item);
    }
}