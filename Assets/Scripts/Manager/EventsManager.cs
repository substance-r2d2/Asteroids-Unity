using System;

namespace EventsManager
{
    public class InputEvents
    {
        public static Action RotateLeft;
        public static Action RotateRight;
        public static Action ForwardThrust;
        public static Action StopForwardThrust;
        public static Action Shoot;
    }

    public class GameEvents
    {
        public static Action GameStart;
        public static Action GamePause;
        public static Action GameOver;
    }

    public class PlayerEvents
    {
        public static Action<int> UpdateLives;
        public static Action<int> GrantScore;
        public static Action<int> UpdateScore;
    }

    public class UI
    {
        public static Action ShowGameOverUI;
    }

    public class Audio
    {
        public static Action PlayAsteroidBlastSFX;
        public static Action PlayShootSFX;
    }
}
