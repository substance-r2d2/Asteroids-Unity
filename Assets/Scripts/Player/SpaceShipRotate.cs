using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Handle Ship Rotation
 */

public class SpaceShipRotate : MonoBehaviour
{
    [SerializeField]
    float RotationSpeed;

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

    void HandleRotateLeft()
    {
        transform.Rotate(new Vector3(0.0f, 0.0f, RotationSpeed) * Time.deltaTime);
    }

    void HandleRotateRight()
    {
        transform.Rotate(new Vector3(0.0f, 0.0f, -RotationSpeed) * Time.deltaTime);
    }
    
    void HandleGameStart()
    {
        EventsManager.InputEvents.RotateLeft += HandleRotateLeft;
        EventsManager.InputEvents.RotateRight += HandleRotateRight;
    }

    void HandleGameOver()
    {
        EventsManager.InputEvents.RotateLeft -= HandleRotateLeft;
        EventsManager.InputEvents.RotateRight -= HandleRotateRight;
    }



    private void OnDestroy()
    {
        EventsManager.InputEvents.RotateLeft -= HandleRotateLeft;
        EventsManager.InputEvents.RotateRight -= HandleRotateRight;
        EventsManager.GameEvents.GameOver -= HandleGameOver;
        EventsManager.GameEvents.GameStart -= HandleGameStart;
    }

}
