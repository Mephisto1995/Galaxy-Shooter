using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class PowerupHandler : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _powerupDuration = 5f;
    [SerializeField] private float _speedPowerupIncrease = 10f;
    [SerializeField] private int _powerupID = -1;

    // Update is called once per frame
    void Update()
    {
        Move();
        DestroyPowerupPrefabOutOfBounds();
    }

    private void DestroyPowerupPrefabOutOfBounds()
    {
        if (transform.position.y < Constants.CAMERA_DOWN_POINT)
        {
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        transform.Translate(Vector2.down * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Constants.TAG_PLAYER)
        {
            Player player = GetPlayerReference();
            player.SetPowerupDuration(_powerupDuration);

            switch (_powerupID)
            {
                case (int)Enums.Powerups.POWERUP_TRIPLE_SHOT:
                    player.ActivateTripleShotPowerup();
                    break;

                case (int)Enums.Powerups.POWERUPT_SPEED:
                    player.ActivateSpeedPowerup();
                    player.SetPowerupSpeedIncrease(_speedPowerupIncrease);
                    break;

                case (int)Enums.Powerups.POWERUP_SHIELD:
                    player.ActivateShieldPowerup();
                    break;

                default:
                    Debug.LogError("PowerupID value is out of bounds: " + _powerupID);
                    break;
            }



            player.SetPowerupSpeedIncrease(_speedPowerupIncrease);
            Destroy(gameObject);
        }
    }

    private Player GetPlayerReference()
    {
        return GameObject.Find(nameof(Player)).GetComponent<Player>();
    }
}
