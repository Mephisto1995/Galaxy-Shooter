using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _laserPrefab;
    [SerializeField] private GameObject _tripleShotPrefab;

    [SerializeField] private float _speed = 0.0f;
    [SerializeField] private float _fireRate = 0.25f;

    private float _canFire = -1f;
    private bool _isTripleShotActive = false;
    private float _powerupDuration = 0.0f;
    private float _timeActivatedPowerup = 0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        KeepPlayerInBounds();
        FireLaserHandler();
        PowerupCancelHandler();
    }

    public void ActivatePowerup()
    {
        _isTripleShotActive = true;
        _timeActivatedPowerup = Time.time;
    }

    private void DeactivatePowerup()
    {
        _isTripleShotActive = false;
    }

    private void PowerupCancelHandler()
    {
        if (_isTripleShotActive && Time.time - _timeActivatedPowerup >= _powerupDuration)
        {
            DeactivatePowerup();
        }
    }

    private void FireLaserHandler()
    {
        if(Input.GetKeyDown(KeyCode.Space) && CanFireSingleShot())
        {
            ProcessLaserFireCooldownCalculation();
            InstantiateLaserPrefab(_isTripleShotActive ? _tripleShotPrefab : _laserPrefab);
        }
    }

    public void SetPowerupDuration(float powerupDuration)
    {
        _powerupDuration = powerupDuration;
    }

    private void InstantiateLaserPrefab(GameObject prefab)
    {
        Vector3 direction = transform.position + new Vector3(0, Constants.LASER_SPAWN_OFFSET, 0);
        GameObject laserInstance = Instantiate(prefab, direction, Quaternion.identity);
    }

    private bool CanFireSingleShot()
    {
        return Time.time > _canFire;
    }

    private void ProcessLaserFireCooldownCalculation()
    {
        _canFire = Time.time + _fireRate;
    }

    private void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis(Constants.HORIZONTAL);
        float verticalInput = Input.GetAxis(Constants.VERTICAL);
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(direction * _speed * Time.deltaTime);
    }

    private void KeepPlayerInBounds()
    {
        // Does not work on different screen ratios (only 16:9). Working on it
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, Constants.BOTTOM_MARGIN, Constants.UPPER_MARGIN), transform.position.z);

        if (transform.position.x >= Constants.RIGHT_MARGIN)
        {
            transform.position = new Vector3(Constants.RIGHT_MARGIN, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < Constants.LEFT_MARGIN)
        {
            transform.position = new Vector3(Constants.LEFT_MARGIN, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Constants.TAG_POWERUP_TRIPLE_SHOT) 
        {
            _isTripleShotActive = true;
        }

        if (collision.tag == Constants.TAG_ENEMY)
        {
            SpawnManager spawnManager = GameObject.Find(nameof(SpawnManager)).GetComponent<SpawnManager>();

            if (spawnManager) 
            {
                spawnManager.PlayerStatus(false);
            }

            Destroy(gameObject);
        }
    }
}
