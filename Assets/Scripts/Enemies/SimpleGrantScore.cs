using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Basic implementation of IGrantScore
 */

public class SimpleGrantScore : MonoBehaviour, IGrantScore
{
    [SerializeField]
    int Score;

    int IGrantScore.Score { get { return Score; } }

    public void GrantScore(int Score)
    {
        EventsManager.PlayerEvents.GrantScore?.Invoke(Score);
    }
}
