using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjLoader : MonoBehaviour
{
    public CharacterScrollList characterScrollList;
    void Start()
    {
        // ResourceDB.Instance.items.ForEach(i =>
        // {

        //     if (i.Ext == "prefab")
        //     {
        //         Debug.Log(i.Path + "/" + i.Name);
        //         characterScrollList.itemList.Add(new CharacterButtonInfo { Name = i.Name });

        //         // Instantiate(Resources.Load<GameObject>(i.Path + "/" + i.Name));

        //     }// Instantiate(Resources.Load<GameObject>("RainEntertainment/FantasyMonster/FireDemon/Prefab/FireDemon"), new Vector2(1.5f, 1.5f), Quaternion.identity);
        // });

    }

    // Update is called once per frame
    void Update()
    {

    }
}
