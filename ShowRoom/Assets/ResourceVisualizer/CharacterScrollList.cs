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

    public GameObject planeGroundStage;


    // Use this for initialization
    void Start()
    {
        this.itemList = new List<CharacterButtonInfo>();
        ResourceDB.Instance.items.ForEach(i =>
        {
            Debug.Log(i.Path);

            if (i.Ext == "prefab")
            {
                Debug.Log(i.Path + "/" + i.Name);
                this.itemList.Add(new CharacterButtonInfo { Name = i.Name, FileName = i.Path + "/" + i.Name });


            }// Instantiate(Resources.Load<GameObject>("RainEntertainment/FantasyMonster/FireDemon/Prefab/FireDemon"), new Vector2(1.5f, 1.5f), Quaternion.identity);
        });
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
            GameObject newButton = buttonObjectPool.GetObject();
            newButton.transform.SetParent(contentPanel);

            Debug.Log(newButton);
            CharacterButton characterButton = newButton.GetComponent<CharacterButton>();
            characterButton.Setup(item, this);
        }
    }

    public void AddCharacterToScene(CharacterButtonInfo item)
    {
        //Accedo a la posicion y la direccion de la camara
        Vector3 pos = Camera.main.transform.position;
        Vector3 fwd = Camera.main.transform.forward;
        Quaternion qua = Camera.main.transform.rotation;
        pos.z += 2;


        // planeGroundStage.AddComponent(Instantiate(Resources.Load<GameObject>(item.FileName), pos, qua));

        Instantiate(Resources.Load<GameObject>(item.FileName), pos, qua);
        // AddItem(item, otherShop);
        RemoveItem(item, this);

        RefreshDisplay();
        // otherShop.RefreshDisplay();
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