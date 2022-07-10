using System.Collections;
using System.Collections.Generic;
using NodeCanvas.Framework;
using NodeCanvas.Tasks.Actions;
using UnityEngine;

public class IsPlayerNearCondition : ConditionTask
{
    private PlayerController playerController;
    public BBParameter<float> interactDistance;
    protected override bool OnCheck()
    {
        if (AppManager.Instance == null)
            return false;
        if (WorldManager.instance.playerController == null)
            return false;
        if (Vector3.Distance(WorldManager.instance.playerController.transform.position, ownerSystemAgent.transform.position)< interactDistance.value)
        {
            return true;
        }
        return false;
    }
}
