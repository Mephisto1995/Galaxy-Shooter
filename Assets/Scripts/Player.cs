using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 0.0f;

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
        const float BOTTOM_MARGIN = -3.8f;
        const float UPPER_MARGIN = 0f;
        const float RIGHT_MARGIN = 11.3f;
        const float LEFT_MARGIN = -RIGHT_MARGIN;

        // Does not work on different screen ratios (only 16:9). Working on it
        if (transform.position.y >= UPPER_MARGIN)
        {
            transform.position = new Vector3(transform.position.x, UPPER_MARGIN, transform.position.z);
        }
        else if (transform.position.y < BOTTOM_MARGIN)
        {
            transform.position = new Vector3(transform.position.x, BOTTOM_MARGIN, transform.position.z);
        }

        if (transform.position.x >= RIGHT_MARGIN)
        {
            transform.position = new Vector3(RIGHT_MARGIN, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < LEFT_MARGIN)
        {
            transform.position = new Vector3(LEFT_MARGIN, transform.position.y, transform.position.z);
        }

        // Player logic to reapper on the opposite corner when going out of bounds
        // Silky smooth transition
        /*if (transform.position.x >= RIGHT_MARGIN)
        {
            transform.position = new Vector3(LEFT_MARGIN, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < LEFT_MARGIN)
        {
            transform.position = new Vector3(RIGHT_MARGIN, transform.position.y, transform.position.z);
        }*/
    }
}
