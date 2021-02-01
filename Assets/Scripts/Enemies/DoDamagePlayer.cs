using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Apply damage to player. Takes into consideration damage cooldown for when player is spawned/respawned
 */

public class DoDamagePlayer : SimpleDoDamage
{
    [SerializeField]
    float PlayerCooldown;

    bool bDoApplyDamage { get { return !(CooldownTime > 0.0f); } }
    float CooldownTime = 0.0f;

    private void OnEnable()
    {
        EventsManager.PlayerEvents.UpdateLives += HandleUpdateLives;
    }

    private void OnDisable()
    {
        EventsManager.PlayerEvents.UpdateLives -= HandleUpdateLives;
    }

    void HandleUpdateLives(int NewLives)
    {
        CooldownTime = PlayerCooldown;
    }


    private void Update()
    {
        if(CooldownTime > 0.0f)
        {
            CooldownTime -= Time.deltaTime;
        }
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && bDoApplyDamage)
        {
            base.OnTriggerEnter2D(collision);
        }
    }
}
