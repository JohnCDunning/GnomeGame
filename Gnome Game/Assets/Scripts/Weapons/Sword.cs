using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : WeaponBase
{
    [SerializeField] private Vector3 attackSize = new Vector3(0.1f, 0.1f, 1f);

    private Vector3 debug_AttackOrigin;
    private Vector3 debug_BoxSize;
    private Vector3 debug_AttackDirection;

    public override void Attack(Transform weaponTransform)
    {

        Vector3 boxSize = new Vector3 (attackSize.x/2, attackSize.y/2, attackSize.z/2);
        Vector3 boxPosition = weaponTransform.position + ((this.transform.forward / 2f) * boxSize.z);
        Collider[] hitColliders = Physics.OverlapBox(boxPosition, boxSize, weaponTransform.rotation);

        debug_AttackDirection = weaponTransform.eulerAngles;
        debug_AttackOrigin = boxPosition;
        debug_BoxSize = boxSize;
    }

    public override void AttackHeavy(Transform atts)
    {
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.matrix = Matrix4x4.TRS(debug_AttackOrigin, Quaternion.Euler(debug_AttackDirection), Vector3.one);
        Gizmos.DrawWireCube(Vector3.zero, debug_BoxSize);
    }
}