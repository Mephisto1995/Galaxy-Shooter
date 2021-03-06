using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utils
{
    public static class Constants
    {
        public static readonly float BOTTOM_MARGIN      = -2.37f;
        public static readonly float UPPER_MARGIN       = 0f;
        public static readonly float RIGHT_MARGIN       = 6.5f;
        public static readonly float LEFT_MARGIN        = -RIGHT_MARGIN;
        public static readonly float CAMERA_UPPER_POINT = 7.0f;
        public static readonly float CAMERA_DOWN_POINT  = -CAMERA_UPPER_POINT;
        public static readonly float CAMERA_RIGHT_POINT = 6.8f;
        public static readonly float CAMERA_LEFT_POINT  = -CAMERA_RIGHT_POINT;
        public static readonly float LASER_SPAWN_OFFSET = 0.8f;

        public static readonly int POWERUP_COOLDOWN_SPAWN_RANGE_LOW = 3;
        public static readonly int POWERUP_COOLDOWN_SPAWN_RANGE_HIGH = 8;

        public static readonly int ENEMY_DESTROYED_SHIP_VALUE = 100;
        public static readonly int ENEMY_DESTROYED_ASTEROID_VALUE = 50;

        public static readonly string HORIZONTAL = "Horizontal";
        public static readonly string VERTICAL   = "Vertical";

        public static readonly string TAG_PLAYER = "Player";
        public static readonly string TAG_ENEMY  = "Enemy";
        public static readonly string TAG_LASER  = "Laser";
        public static readonly string TAG_EXPLOSION  = "Explosion";
        public static readonly string TAG_POWERUP_TRIPLE_SHOT  = "TripleShotPowerup";
        public static readonly string TAG_POWERUP_SPEED = "SpeedPowerup";

        public static readonly string STRING_SCORE = "Score: ";
        public static readonly string STRING_GAME_OVER = "GAME OVER";
        public static readonly string STRING_RESTART = "Press R to Restart the Game";

        public static readonly int SCENE_MAIN_MENU = 0;
        public static readonly int SCENE_GAME = 1;

        public static readonly string TRIGGER_ENEMY_DESTROYED_ANIMATION = "OnEnemyDeath";

        public static readonly float ENEMY_SHIP_DESTROYED_DELAY = 2.8f;
        public static readonly float EXPLOSION_DESTROYED_DELAY = 1.5f;
        public static readonly float SPAWN_DELAY = 3.0f;
    }

    public static class Enums
    {
        public enum Powerups : int
        {
            POWERUP_UNKNOWN = -1,
            POWERUP_TRIPLE_SHOT,
            POWERUPT_SPEED,
            POWERUP_SHIELD,

            NUM_POWERUPS
        }

        public enum Enemies : int
        {
            ENEMY_UNKOWN = -1,
            ENEMY_SHIP,
            ENEMY_ASTEROID,

            NUM_ENEMIES
        }
    }

    public static class HelperFunctions
    {
        public static Player GetPlayerReference()
        {
            return GameObject.Find(nameof(Player)).GetComponent<Player>();
        }

        public static SpawnManager GetSpawnManagerReference()
        {
            return GameObject.Find(nameof(SpawnManager)).GetComponent<SpawnManager>(); ;
        }

        public static UIManager GetUIManagerReference()
        {
            return GameObject.Find(nameof(Canvas)).GetComponent<UIManager>();
        }

        public static GameManager GetGameManagerReference()
        {
            return GameObject.Find(nameof(GameManager)).GetComponent<GameManager>();
        }

        public static void LoadScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }

        // mostly used for objects created at startup
        public static void NullCheck(object obj)
        {
            if (obj == null)
            {
                Debug.LogError(obj.ToString() + " is null!");
            }
        }

        public static Enums.Enemies GetEnemyType(int enemyId)
        {
            Debug.Log("HelperFunctions.GetEnemyType() enemyId: " + enemyId);

            switch (enemyId)
            {
                case (int)Enums.Enemies.ENEMY_ASTEROID:
                    return Enums.Enemies.ENEMY_ASTEROID;

                case (int)Enums.Enemies.ENEMY_SHIP:
                    return Enums.Enemies.ENEMY_SHIP;

                default:
                    return Enums.Enemies.ENEMY_UNKOWN;
            }
        }

        public static Enums.Powerups GetPowerupType(int powerupId)
        {
            Debug.Log("HelperFunctions.GetPowerupType() powerupId: " + powerupId);

            switch (powerupId)
            {
                case (int)Enums.Powerups.POWERUP_TRIPLE_SHOT:
                    return Enums.Powerups.POWERUP_TRIPLE_SHOT;

                case (int)Enums.Powerups.POWERUPT_SPEED:
                    return Enums.Powerups.POWERUPT_SPEED;

                case (int)Enums.Powerups.POWERUP_SHIELD:
                    return Enums.Powerups.POWERUP_SHIELD;

                default:
                    return Enums.Powerups.POWERUP_UNKNOWN;
            }
        }
    }
}
