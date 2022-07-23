using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

[System.Serializable]
public class InventoryGroup
{
    [SerializeField] Transform inventoryGroupRoot;
    [SerializeField] private List<InventoryContainer> containers;
}
public class InventoryController : MonoBehaviour
{
    public InventoryGroup[] inventoryGroups;

    private Dictionary<int, GameObject> ObjectInformation;

    public InventoryData GenerateInventoryData(Guid typeID, int initialStack)
    {
        if (AppManager.Instance.ItemFactory.GetItemData(typeID, out ItemScriptableObject itemData))
        {
            return new InventoryData()
            {
                stackCount = initialStack,
                type = typeID,
                uiElement = itemData.inventoryIcon
            };
        }
        return null;
    }
}
