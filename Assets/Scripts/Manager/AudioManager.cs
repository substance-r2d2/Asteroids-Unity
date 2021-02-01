using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Handles SFX events
 */

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    AudioSource SFXAudioSource;

    [Header("AUDIO CLIPS")]
    [SerializeField]
    AudioClip BlastSFX;

    [SerializeField]
    AudioClip ShootSFX;

    [SerializeField]
    AudioClip UpdateLivesSFX;

    [SerializeField]
    AudioClip GameOverSFX;

    private void OnEnable()
    {
        EventsManager.Audio.PlayAsteroidBlastSFX += HandlePlayAsteroidBlastSFX;
        EventsManager.Audio.PlayShootSFX += HandlePlayShootSFX;

        EventsManager.PlayerEvents.UpdateLives += HandleUpdateLives;

        EventsManager.GameEvents.GameOver += HandleGameOver;
    }

    private void OnDisable()
    {
        EventsManager.Audio.PlayAsteroidBlastSFX -= HandlePlayAsteroidBlastSFX;
        EventsManager.Audio.PlayShootSFX -= HandlePlayShootSFX;

        EventsManager.PlayerEvents.UpdateLives -= HandleUpdateLives;

        EventsManager.GameEvents.GameOver -= HandleGameOver;
    }

    void HandlePlayAsteroidBlastSFX()
    {
        PlayOneShot(BlastSFX);
    }

    void HandlePlayShootSFX()
    {
        PlayOneShot(ShootSFX);
    }

    void HandleUpdateLives(int NewLives)
    {
        PlayOneShot(UpdateLivesSFX);
    }

    void HandleGameOver()
    {
        PlayOneShot(GameOverSFX);
    }

    void PlayOneShot(AudioClip clip)
    {
        SFXAudioSource.PlayOneShot(clip);
    }

}
