using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayHighScore : MonoBehaviour
{
    TMP_Text Label;

    int CurrentHiScore;

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

        CurrentHiScore = PlayerProfileHandler.Instance.CurrentHiScore;

        Label.text = string.Format("HI-SCORE: {0}", CurrentHiScore);
    }

    void HandleUpdateScore(int NewScore)
    {
        if(NewScore > CurrentHiScore)
        {
            Label.text = string.Format("HI-SCORE: {0}", NewScore);
        }
    }
}
