using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Simple implementation of ITakeDamage interface.
 */
public class SimpleTakeDamage : MonoBehaviour, ITakeDamage
{
    [SerializeField]
    int SetupHealth;

    public int MaxHealth { get { return SetupHealth; } }

    public int CurrHealth { get { return CurrentHealth; } set { CurrentHealth = value; } }
    int CurrentHealth;

    public Action<int> ModifyHealth { get; set; }

    public void TakeDamage(int Damage)
    {
        CurrHealth -= Damage;

        ModifyHealth?.Invoke(CurrHealth);
    }
}
