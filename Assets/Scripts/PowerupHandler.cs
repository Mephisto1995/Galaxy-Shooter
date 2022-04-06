using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class PowerupHandler : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _powerupDuration = 5f;
    [SerializeField] private float _speedPowerupIncrease = 10f;
    [SerializeField] private int _powerupId = -1;

    private Player _player;

    private void Start()
    {
        _player = HelperFunctions.GetPlayerReference();
    }

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
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Constants.TAG_PLAYER)
        {
            _player.SetPowerupDuration(_powerupDuration);

            if (_player)
            {
                switch (_powerupId)
                {
                    case (int)Enums.Powerups.POWERUP_TRIPLE_SHOT:
                        _player.ActivateTripleShotPowerup();
                        break;

                    case (int)Enums.Powerups.POWERUPT_SPEED:
                        _player.ActivateSpeedPowerup();
                        _player.SetPowerupSpeedIncrease(_speedPowerupIncrease);
                        break;

                    case (int)Enums.Powerups.POWERUP_SHIELD:
                        _player.ActivateShieldPowerup();
                        break;

                    default:
                        Debug.LogError("PowerupID value is out of bounds: " + _powerupId);
                        break;
                }
            }

            Destroy(gameObject);
        }
    }
}
