using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class ItemFactory : MonoBehaviour
{

    public Dictionary<Guid, ItemScriptableObject> itemDictionary = new Dictionary<Guid, ItemScriptableObject>();
   
    [TableList]
    public List<ItemScriptableObject> itemScriptableObjects = new List<ItemScriptableObject>();
    
    public void Initialize()
    {
        foreach (ItemScriptableObject item in itemScriptableObjects)
        {
            bool success = itemDictionary.TryAdd(item.itemID, item);
            if (!success)
                throw new Exception($"Issue adding item {item.name}");
        }
    }
    public bool GetItemData(Guid guid, out ItemScriptableObject data)
    {
        data = null;
        if (!itemDictionary.ContainsKey(guid)) return false;
        data = itemDictionary[guid];
        return true;
    }
}
