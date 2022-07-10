using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Weapons.Attacks;
using Vector3 = UnityEngine.Vector3;

public class StaffAttack : MonoBehaviour, IAttack
{
    [SerializeField] private AttackFlags attackFlags;
    [SerializeField] private float damage = 25f;
    [SerializeField] private Vector3 velocity;
    private GameObject attackSender;
    public void Initialize(Vector3 targetVelocity, GameObject sender)
    {
        velocity = targetVelocity;
        this.attackSender = sender;

        Destroy(this.gameObject, 10f);
    }

    private void Update()
    {
        this.transform.Translate(velocity * Time.deltaTime);
    }

    public GameObject GetSender()
    {
        return this.attackSender;
    }

    public void Interact(IDamageable target)
    {
        target.HandleInteraction(this);
        Destroy(this.gameObject);
    }

    public AttackFlags GetFlags()
    {
        return attackFlags;
    }

    public float GetDamage()
    {
        return damage;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            if (damageable.GetOwner() != this.GetSender())
                Interact(damageable);
        }
    }
}