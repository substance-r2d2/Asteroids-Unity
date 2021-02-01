using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Handles ship movement
 */
public class SpaceShipMoveForward : MonoBehaviour
{
    [SerializeField]
    float ThrustMagnitude = 15.0f;

    Rigidbody2D RigidBody = null;

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

    private void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();
    }

    void HandleForwardThrust()
    {
        RigidBody.velocity = transform.up * ThrustMagnitude;
    }

    void HandleGameOver()
    {
        EventsManager.InputEvents.ForwardThrust -= HandleForwardThrust;
    }

    void HandleGameStart()
    {
        EventsManager.InputEvents.ForwardThrust += HandleForwardThrust;
    }

    private void OnDestroy()
    {
        EventsManager.GameEvents.GameOver -= HandleGameOver;
        EventsManager.GameEvents.GameStart -= HandleGameStart;
        EventsManager.InputEvents.ForwardThrust -= HandleForwardThrust;
    }

}
