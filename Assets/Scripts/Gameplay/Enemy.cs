using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _enemyId = -1;

    private Player _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = HelperFunctions.GetPlayerReference();
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();

        if (IsEnemyOutOfBounds()) 
        {
            Destroy(gameObject);
        }
    }

    private void MoveEnemy()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    private bool IsEnemyOutOfBounds()
    {
        return transform.position.y < Constants.CAMERA_DOWN_POINT;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Constants.TAG_LASER || collision.tag == Constants.TAG_PLAYER && _player.IsShieldActive())
        {
            Debug.Log("Enemy.OnTriggerEnter2D(): _enemyId: " + _enemyId);

            if (_player)
            {
                switch (_enemyId)
                {
                    case (int)Enums.Enemies.ENEMY_SHIP:
                        _player.HandleScoreSystem(Constants.ENEMY_DESTROYED_SHIP_VALUE);
                        break;

                    case (int)Enums.Enemies.ENEMY_ASTEROID:
                        _player.HandleScoreSystem(Constants.ENEMY_DESTROYED_ASTEROID_VALUE);
                        break;

                    default:
                        Debug.LogError("Invalid enemy id: " + _enemyId);
                        break;
                }
            }
        }

        Destroy(gameObject);
    }
}
