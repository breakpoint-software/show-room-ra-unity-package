using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
public class CharacterScrollList : MonoBehaviour
{
    public List<CharacterButtonInfo> itemList;
    public Transform contentPanel;
    public CharacterScrollList otherShop;
    public ButtonObjectPool buttonObjectPool;


    // Use this for initialization
    void Start()
    {
        Debug.Log("CharacterScrollList -> start");
        RefreshDisplay();
    }

    void Update()
    {
        // RefreshDisplay();
    }
    void RefreshDisplay()
    {
        Debug.Log("RefreshDisplay");
        RemoveButtons();
        AddButtons();
    }

    private void RemoveButtons()
    {
        Debug.Log("RemoveButtons");
        while (contentPanel.childCount > 0)
        {
            GameObject toRemove = transform.GetChild(0).gameObject;
            buttonObjectPool.ReturnObject(toRemove);
        }
    }

    private void AddButtons()
    {
        Debug.Log("AddButtons" + itemList.Count.ToString());

        for (int i = 0; i < itemList.Count; i++)
        {
            CharacterButtonInfo item = itemList[i];
            Debug.Log("Button " + item.Name);
            GameObject newButton = buttonObjectPool.GetObject();
            newButton.transform.SetParent(contentPanel);

            CharacterButton sampleButton = newButton.GetComponent<CharacterButton>();
            sampleButton.Setup(item, this);
        }
    }

    public void TryTransferItemToOtherShop(CharacterButtonInfo item)
    {
        //     gold += item.price;
        //     otherShop.gold -= item.price;

        AddItem(item, otherShop);
        RemoveItem(item, this);

        RefreshDisplay();
        otherShop.RefreshDisplay();
        Debug.Log("enough gold");

        Debug.Log("attempted");
    }

    void AddItem(CharacterButtonInfo itemToAdd, CharacterScrollList characterList)
    {
        characterList.itemList.Add(itemToAdd);
    }

    private void RemoveItem(CharacterButtonInfo itemToRemove, CharacterScrollList shopList)
    {
        for (int i = shopList.itemList.Count - 1; i >= 0; i--)
        {
            if (shopList.itemList[i] == itemToRemove)
            {
                shopList.itemList.RemoveAt(i);
            }
        }
    }
}