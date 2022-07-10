using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : WeaponBase
{
    [SerializeField] private float attackProjectileSpeed = 10f;
    [SerializeField] private GameObject attack;
    [SerializeField] private Transform projectilePoint;
    public override void Attack(Vector3 playerDirection)
    {
        GameObject attackObject =
            Instantiate(attack,
                projectilePoint.position,
                Quaternion.Euler(playerDirection)
                );

        StaffAttack staffAttack = attackObject.GetComponent<StaffAttack>();
        staffAttack.Initialize(playerDirection * attackProjectileSpeed, owner);

    }
}