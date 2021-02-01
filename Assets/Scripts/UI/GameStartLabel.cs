using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartLabel : MonoBehaviour
{
    private void OnEnable()
    {
        EventsManager.GameEvents.GameStart += HandleGameStart;
    }

    private void OnDisable()
    {
        EventsManager.GameEvents.GameStart -= HandleGameStart;
    }

    void HandleGameStart()
    {
        GetComponent<TMPro.TMP_Text>().gameObject.SetActive(false);
    }
}
