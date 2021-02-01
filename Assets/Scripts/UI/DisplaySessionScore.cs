using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplaySessionScore : MonoBehaviour
{
    TMP_Text ScoreLabel;

    private void OnEnable()
    {
        if (PlayerProfileHandler.Instance != null)
        {
            ScoreLabel = GetComponent<TMP_Text>();
            ScoreLabel.text = string.Format("SCORE: {0}", PlayerProfileHandler.Instance.SessionScore);
        }
    }
}
