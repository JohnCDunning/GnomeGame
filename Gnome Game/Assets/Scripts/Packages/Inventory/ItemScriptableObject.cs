using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;


[CreateAssetMenu(fileName = "Item", menuName = "Items/Create New Item", order = 1)]
public class ItemScriptableObject : ScriptableObject
{
    [PreviewField(ObjectFieldAlignment.Center)] public Sprite inventoryIcon;
    [InlineButton("GenerateID", "Generate")]
    public string itemIDReadable;
    public string itemName;
    public Guid itemID;
    public GameObject itemWorldPrefab;
    

    private void GenerateID()
    {
        itemID = Guid.NewGuid();
        itemIDReadable = itemID.ToString();
    }

    private void Reset()
    {
        GenerateID();
    }
}
