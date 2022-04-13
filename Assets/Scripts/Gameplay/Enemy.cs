using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _enemyId = -1;
    [SerializeField] private float _rotationSpeed = 10f;
    [SerializeField] private GameObject _explosion;

    private Animator _animator;
    private SpawnManager _spawnManager;
    private Player _player;

    [SerializeField] private bool _enemyShipAnimationInProgress = false;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _spawnManager = HelperFunctions.GetSpawnManagerReference();
        _player = HelperFunctions.GetPlayerReference();

        HelperFunctions.NullCheck(_animator);
        HelperFunctions.NullCheck(_spawnManager);
        HelperFunctions.NullCheck(_player);
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();

        if (HelperFunctions.GetEnemyType(_enemyId) == Enums.Enemies.ENEMY_ASTEROID)
        {
            RotateAsteroid();
        }

        if (IsEnemyOutOfBounds()) 
        {
            Destroy(gameObject);
        }
    }

    public bool GetEnemyShipAnimationInProgress()
    {
        return _enemyShipAnimationInProgress;
    }

    private void MoveEnemy()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    private void RotateAsteroid()
    {
        transform.Rotate(Vector3.forward * _rotationSpeed * Time.deltaTime);
    }

    private bool IsEnemyOutOfBounds()
    {
        return transform.position.y < Constants.CAMERA_DOWN_POINT;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        Debug.Log("Enemy.OnTriggerEnter2D(): _enemyId: " + _enemyId);

        if (collision.tag == Constants.TAG_LASER /*|| collision.tag == Constants.TAG_PLAYER && player && player.IsShieldActive()*/)
        {
            Debug.Log("Enemy.OnTriggerEnter2D(): _enemyId: " + _enemyId);
            HandleEnemyDestroyedScoringSystem(_player);
            DestroyEnemySequence();
            return;
        }

        if (collision.tag == Constants.TAG_PLAYER)
        {
            DestroyEnemySequence();
        }
    }
    
    IEnumerator ExplosionTimerCoroutine()
    {
        _enemyShipAnimationInProgress = true;
        yield return new WaitForSeconds(Constants.EXPLOSION_DESTROYED_DELAY);
        _enemyShipAnimationInProgress = false;
        //Destroy(gameObject); ?
    }

    private void DestroyEnemySequence()
    {
        _speed = 0;
        _spawnManager.StartSpawning();

        if (HelperFunctions.GetEnemyType(_enemyId) == Enums.Enemies.ENEMY_ASTEROID)
        {
            GameObject explosion = Instantiate(_explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            StartCoroutine(ExplosionTimerCoroutine());
            Destroy(explosion, Constants.EXPLOSION_DESTROYED_DELAY);
        }
        else
        {
            StartCoroutine(ExplosionTimerCoroutine());
            Destroy(gameObject, Constants.ENEMY_SHIP_DESTROYED_DELAY);
            _animator.SetTrigger(Constants.TRIGGER_ENEMY_DESTROYED_ANIMATION);
        }
    }

    private void HandleEnemyDestroyedScoringSystem(Player player)
    {
        if (player)
        {
            switch (_enemyId)
            {
                case (int)Enums.Enemies.ENEMY_SHIP:
                    player.HandleScoreSystem(Constants.ENEMY_DESTROYED_SHIP_VALUE);
                    break;

                case (int)Enums.Enemies.ENEMY_ASTEROID:
                    player.HandleScoreSystem(Constants.ENEMY_DESTROYED_ASTEROID_VALUE);
                    break;

                default:
                    Debug.LogError("Invalid enemy id: " + _enemyId);
                    break;
            }
        }
    }
}
