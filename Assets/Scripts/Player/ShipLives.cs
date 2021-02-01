using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Keep Track of player remaining lives
 * Game over when reamining lives is less than zero
 */

public class ShipLives : MonoBehaviour
{
    [SerializeField]
    int Lives;

    int RemainingLives;

    ITakeDamage TakeDamage;

    private void OnEnable()
    {
        if(TakeDamage != null)
        {
            TakeDamage.ModifyHealth += HandleHealthModify;
        }

        EventsManager.GameEvents.GameStart += HandleGameStart;
    }

    private void OnDisable()
    {
        TakeDamage.ModifyHealth -= HandleHealthModify;

        EventsManager.GameEvents.GameStart -= HandleGameStart;
    }

    private void Start()
    {
        TakeDamage = GetComponent<ITakeDamage>();

        TakeDamage.ModifyHealth += HandleHealthModify;

        RemainingLives = Lives;
    }

    void HandleHealthModify(int NewHealth)
    {
        if(NewHealth <= 0)
        {
            --RemainingLives;

            EventsManager.PlayerEvents.UpdateLives?.Invoke(RemainingLives);

            if(RemainingLives < 0)
            {
                EventsManager.GameEvents.GameOver?.Invoke();
            }
        }
    }


    void HandleGameStart()
    {
        EventsManager.PlayerEvents.UpdateLives?.Invoke(RemainingLives);
    }
}
