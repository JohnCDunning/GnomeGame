using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class InventoryData
{
    public Sprite uiElement;
    public int stackCount;
    public Guid type;

    public bool MergeItem(InventoryData other)
    {
        //
        // TODO: Add upper limit of item stack
        //
        if (type != other.type)
            return false;
        
        stackCount += other.stackCount;
        return true;
        
    }
}
public class InventoryContainer : MonoBehaviour
{
    public InventoryData inventoryData;
}
