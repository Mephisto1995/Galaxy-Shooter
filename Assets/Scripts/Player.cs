using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 0.0f;
    [SerializeField] private GameObject _laserPrefab;
    [SerializeField] private float _fireRate = 0.25f;

    private float _canFire = -1f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, -1.11f, -2.54f);
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
        Vector3 direction = transform.position + new Vector3(0, 0.8f, 0);
        Instantiate(_laserPrefab, direction, Quaternion.identity);
    }

    private void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(direction * _speed * Time.deltaTime);
    }

    private void KeepPlayerInBounds()
    {
        const float BOTTOM_MARGIN = -2.37f;
        const float UPPER_MARGIN = 0f;
        const float RIGHT_MARGIN = 6.5f;
        const float LEFT_MARGIN = -RIGHT_MARGIN;

        // Does not work on different screen ratios (only 16:9). Working on it
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, BOTTOM_MARGIN, UPPER_MARGIN), transform.position.z);

        if (transform.position.x >= RIGHT_MARGIN)
        {
            transform.position = new Vector3(RIGHT_MARGIN, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < LEFT_MARGIN)
        {
            transform.position = new Vector3(LEFT_MARGIN, transform.position.y, transform.position.z);
        }
    }
}
