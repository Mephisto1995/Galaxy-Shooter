using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class PowerupHandler : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _powerupDuration = 5f;
    [SerializeField] private float _speedPowerupIncrease = 10f;

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
            player.SetPowerupSpeedIncrease(_speedPowerupIncrease);
            Destroy(gameObject);
        }
    }

    private Player GetPlayerReference()
    {
        return GameObject.Find(nameof(Player)).GetComponent<Player>();
    }
}
