using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class Laser : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _tripleShotPrefab;
    
    // Update is called once per frame
    void Update()
    {
        MoveUp();
        DestroyLaserObject();
    }

    private void MoveUp()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
    }

    private void DestroyLaserHandler()
    {
        Player player = GameObject.Find(nameof(Player)).GetComponent<Player>();

        if (player != null)
        {
            Destroy(player.IsTripleShotActive() ? _tripleShotPrefab : gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void DestroyLaserObject()
    {
        if (transform.position.y > Constants.CAMERA_UPPER_POINT)
        {
            DestroyLaserHandler();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == Constants.TAG_ENEMY)
        {
            DestroyLaserHandler();
        }
    }
}
