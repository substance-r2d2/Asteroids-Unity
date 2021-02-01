using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Blink and reset player postion when player lives are modified
 */

public class ShipRespawn : MonoBehaviour
{
    private void OnEnable()
    {
        EventsManager.PlayerEvents.UpdateLives += HandleUpdateLives;
    }

    private void OnDisable()
    {
        EventsManager.PlayerEvents.UpdateLives -= HandleUpdateLives;
    }


    void HandleUpdateLives(int RemainingLives)
    {
        if(RemainingLives >= 0)
        {
            StartCoroutine(BlinkAndResetPlayer());
        }
    }

    IEnumerator BlinkAndResetPlayer()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;

        transform.position = Vector2.zero;

        for (int i = 0; i < 5; i++)
        {
            sprite.color = Color.clear;
            yield return new WaitForSeconds(0.2f);
            sprite.color = Color.white;
            yield return new WaitForSeconds(0.2f);
        }
    }

}
