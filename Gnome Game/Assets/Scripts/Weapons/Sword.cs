using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Matrix4x4 = UnityEngine.Matrix4x4;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class Sword : WeaponBase
{
    [SerializeField] private Vector3 attackSize = new Vector3(0.1f, 0.1f, 1f);

    public override void Attack(Vector3 playerFacingDirection)
    {
    }

    public override void AttackHeavy(Transform atts)
    {
    }
}