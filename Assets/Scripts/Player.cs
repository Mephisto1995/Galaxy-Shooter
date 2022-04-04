using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 0.0f;
    [SerializeField] private GameObject _laserPrefab;
    [SerializeField] private float _fireRate = 0.25f;

    private float _canFire = -1f;

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

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            FireLaser();
        }
    }

    private void FireLaser()
    {
        _canFire = Time.time + _fireRate;
        Vector3 direction = transform.position + new Vector3(0, Constants.LASER_SPAWN_OFFSET, 0);
        Instantiate(_laserPrefab, direction, Quaternion.identity);
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == Constants.TAG_ENEMY) 
        {
            SpawnManager spawnManager = GameObject.Find(nameof(SpawnManager)).gameObject.GetComponent<SpawnManager>();
            const bool isAlive = false;
            spawnManager.PlayerStatus(isAlive);
            Destroy(gameObject);
        }
    }
}
