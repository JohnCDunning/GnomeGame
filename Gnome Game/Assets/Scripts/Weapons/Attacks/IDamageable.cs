using UnityEngine;

public interface IDamageable
{

    public GameObject GetOwner();
    public void HandleInteraction(IAttack sender);
}