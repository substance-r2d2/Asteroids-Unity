using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Triggers input event
 * TODO : Create IPlatformInput and then based on current platform create correct object
 */

public class InputManager : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            EventsManager.InputEvents.RotateLeft?.Invoke();
        }
        else if(Input.GetKey(KeyCode.D))
        {
            EventsManager.InputEvents.RotateRight?.Invoke();
        }
        
        if(Input.GetKeyDown(KeyCode.W))
        {
            EventsManager.InputEvents.ForwardThrust?.Invoke();
        }
        else if(Input.GetKey(KeyCode.W) || Input.GetKeyUp(KeyCode.W))
        {
            EventsManager.InputEvents.StopForwardThrust?.Invoke();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            EventsManager.InputEvents.Shoot?.Invoke();
        }
    }
}
