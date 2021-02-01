using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Handles ship shooting 
 */

public class SpaceShipWeaponFire : MonoBehaviour
{
    IWeapon Weapon;

    private void OnEnable()
    {
        EventsManager.GameEvents.GameOver += HandleGameOver;
        EventsManager.GameEvents.GameStart += HandleGameStart;
    }

    private void OnDisable()
    {
        EventsManager.GameEvents.GameOver -= HandleGameOver;
        EventsManager.GameEvents.GameStart -= HandleGameStart;
    }

    void Start()
    {
        Weapon = GetComponent<IWeapon>();   
    }

    void HandleShoot()
    {
        Weapon.FireWeapon(transform);
    }

    void HandleGameOver()
    {
        EventsManager.InputEvents.Shoot -= HandleShoot;
    }

    void HandleGameStart()
    {
        EventsManager.InputEvents.Shoot += HandleShoot;
    }

    private void OnDestroy()
    {
        EventsManager.InputEvents.Shoot -= HandleShoot;
        EventsManager.GameEvents.GameOver -= HandleGameOver;
        EventsManager.GameEvents.GameStart -= HandleGameStart;
    }
}
