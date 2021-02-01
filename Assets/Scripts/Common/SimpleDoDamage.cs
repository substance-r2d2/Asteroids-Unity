using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Simple implementation of IDoDamage interface.
 */

public class SimpleDoDamage : MonoBehaviour, IDoDamage
{
    [SerializeField]
    int Damage;

    public int DamageToApply { get { return Damage; } }

    public System.Action<ITakeDamage> DamageApplied { get; set; }

    public void ApplyDamage(int Damage, ITakeDamage ApplyTo)
    {
        ApplyTo.TakeDamage(Damage);
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        ITakeDamage takeDamage = collision.GetComponent<ITakeDamage>();
        if(takeDamage != null)
        {
            ApplyDamage(DamageToApply, takeDamage);

            DamageApplied?.Invoke(takeDamage);
        }
    }
}
