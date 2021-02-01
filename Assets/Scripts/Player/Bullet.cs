using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Does damamge and pools itself after doing so
 */

public class Bullet : MonoBehaviour
{
    IDoDamage DoDamage;
    IPoolable Poolable;

    private void OnEnable()
    {
        if (DoDamage != null)
        {
            DoDamage.DamageApplied += HandleDamageApplied;
        }
    }

    private void OnDisable()
    {
        DoDamage.DamageApplied -= HandleDamageApplied;
    }

    void Start()
    {
        Poolable = GetComponent<IPoolable>();

        DoDamage = GetComponent<IDoDamage>();

        DoDamage.DamageApplied += HandleDamageApplied;
    }

    void HandleDamageApplied(ITakeDamage DamageAppliedTo)
    {
        Poolable.Pool();
    }
}
