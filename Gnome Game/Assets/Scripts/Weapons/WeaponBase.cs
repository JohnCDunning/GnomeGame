using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    public GameObject owner;
    public virtual void Attack(Vector3 playerDirection)
    {

    }

    public void Attach(Transform point, GameObject weaponOwner)
    {
        this.transform.parent = point;
        this.transform.localPosition = Vector3.zero;
        this.transform.localRotation = quaternion.identity;
        this.owner = weaponOwner;

    }

    public virtual void AttackHeavy(Transform weaponTransform)
    {

    }
}