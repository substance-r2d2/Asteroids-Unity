using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayCurrentScore : MonoBehaviour
{
    TMP_Text Label;

    private void OnEnable()
    {
        EventsManager.PlayerEvents.UpdateScore += HandleUpdateScore;
    }

    private void OnDisable()
    {
        EventsManager.PlayerEvents.UpdateScore -= HandleUpdateScore;
    }

    void Start()
    {
        Label = GetComponent<TMP_Text>();

        Label.text = string.Format("SCORE: {0}", PlayerProfileHandler.Instance.SessionScore);
    }

    void HandleUpdateScore(int NewScore)
    {
        Label.text = string.Format("SCORE: {0}", NewScore);
    }
}
