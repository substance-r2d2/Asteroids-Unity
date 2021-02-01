using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Hadles game start and reloading of game on game over
 */

public class SessionStartEndTracker : MonoBehaviour
{
    bool bGameOver = false;

    private void OnEnable()
    {
        EventsManager.InputEvents.Shoot += HandleGameStart;
        EventsManager.GameEvents.GameOver += HandleGameOver;
    }

    private void OnDisable()
    {
        EventsManager.InputEvents.Shoot -= HandleGameStart;
        EventsManager.GameEvents.GameOver -= HandleGameOver;
    }

    void HandleGameStart()
    {
        EventsManager.GameEvents.GameStart?.Invoke();

        EventsManager.InputEvents.Shoot -= HandleGameStart;
    }

    //Wait for a bit before binding restart button as it is fire button as well
    void HandleGameOver()
    {
        Invoke("BindRestartButtonEvent", 1.5f);
    }

    void BindRestartButtonEvent()
    {
        EventsManager.InputEvents.Shoot += HandleGameRestart;
    }

    private void OnDestroy()
    {
        EventsManager.InputEvents.Shoot -= HandleGameRestart;
    }

    void HandleGameRestart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
