using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Takes damage and grants score when health goes below zero 
 */

[RequireComponent(typeof(IGrantScore))]
public class TakeDamageAndGrantScore : SimpleTakeDamage
{
    IGrantScore GrantScore;

    private void OnEnable()
    {
        ModifyHealth += HandleModifyHealth; 
    }

    private void OnDisable()
    {
        ModifyHealth -= HandleModifyHealth;
    }

    private void Start()
    {
        GrantScore = GetComponent<IGrantScore>();
    }

    void HandleModifyHealth(int NewHealth)
    {
        if(NewHealth <= 0)
        {
            GrantScore.GrantScore(GrantScore.Score);
        }
    }
}
