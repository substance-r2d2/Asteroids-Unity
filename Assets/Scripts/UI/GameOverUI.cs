using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    TMP_Text[] TextLabels;

    private void OnEnable()
    {
        EventsManager.UI.ShowGameOverUI += HandleGameOver;
    }

    private void OnDisable()
    {
        EventsManager.UI.ShowGameOverUI -= HandleGameOver;
    }

    private void Start()
    {
        TextLabels = GetComponentsInChildren<TMP_Text>();

        for (int i = 0; i < TextLabels.Length; i++)
        {
            TextLabels[i].gameObject.SetActive(false);
        }
    }

    void HandleGameOver()
    {
        for (int i = 0; i < TextLabels.Length; i++)
        {
            TextLabels[i].gameObject.SetActive(true);
        }

        GetComponent<UnityEngine.UI.Image>().color = Color.white;
    }
}
