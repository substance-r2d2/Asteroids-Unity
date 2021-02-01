using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Listens and updates score
 * Also updates and saves hi-score
 */

public class ScoreTracker : MonoBehaviour
{
    int CurrentScore = 0;

    private void OnEnable()
    {
        EventsManager.PlayerEvents.GrantScore += HandleGrantScore;
        EventsManager.GameEvents.GameOver += HandleGameOver;
    }

    private void OnDisable()
    {
        EventsManager.PlayerEvents.GrantScore -= HandleGrantScore;
        EventsManager.GameEvents.GameOver -= HandleGameOver;
    }

    void HandleGrantScore(int score)
    {
        CurrentScore += score;

        EventsManager.PlayerEvents.UpdateScore?.Invoke(CurrentScore);
    }
    
    void HandleGameOver()
    {
        //int CurrentHiScore = PlayerPrefs.GetInt(PlayerSaveKeyConstants.HiScoreKey, 0);
        //if(CurrentScore > CurrentHiScore)
        //{
        //    Debug.LogError("SAVE DATA");
        //    PlayerPrefs.SetInt(PlayerSaveKeyConstants.HiScoreKey, CurrentHiScore);
        //    PlayerPrefs.Save();
        //}

        //Debug.LogError("AGAIN SAVE DATA");
        //PlayerPrefs.SetInt(PlayerSaveKeyConstants.SessionScoreKey, CurrentScore);

        //PlayerPrefs.Save();

        PlayerProfileHandler.Instance.UpdateSessionScore(CurrentScore);

        EventsManager.UI.ShowGameOverUI?.Invoke();
    }
}
