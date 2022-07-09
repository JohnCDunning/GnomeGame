using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons.Attacks;

public interface IAttack
{
    public GameObject GetSender();
    public void Interact(IDamageable target);
    public AttackFlags GetFlags();
    public float GetDamage();
}