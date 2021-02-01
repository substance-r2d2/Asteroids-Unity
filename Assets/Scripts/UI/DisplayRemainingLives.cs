using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayRemainingLives : MonoBehaviour
{
    TMP_Text Label;

    private void Start()
    {
        Label = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        EventsManager.PlayerEvents.UpdateLives += HandleUpdateLives;
    }

    private void OnDisable()
    {
        EventsManager.PlayerEvents.UpdateLives -= HandleUpdateLives;
    }
    
    void HandleUpdateLives(int lives)
    {
        Label.text = string.Format("REMAINING LIVES: {0}", lives);
    }
}
