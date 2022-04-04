using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();

        if (ShouldDestroyEnemy()) 
        {
            Destroy(_enemyPrefab);
        }
    }

    private void MoveEnemy()
    {
        transform.Translate(Vector2.down * _speed * Time.deltaTime);
    }

    private bool ShouldDestroyEnemy()
    {
        return transform.position.y < Constants.CAMERA_DOWN_POINT;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == Constants.TAG_LASER || collision.gameObject.tag == Constants.TAG_POWERUP_TRIPLE_SHOT || collision.gameObject.tag == Constants.TAG_PLAYER)
        {
            Destroy(_enemyPrefab);
        }
    }
}
