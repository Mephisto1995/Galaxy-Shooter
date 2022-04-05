using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    // Start is called before the first frame update
    void Start()
    {

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
        transform.Translate(Vector2.down * _speed * Time.deltaTime);
    }

    private bool IsEnemyOutOfBounds()
    {
        return transform.position.y < Constants.CAMERA_DOWN_POINT;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Constants.TAG_LASER || collision.gameObject.tag == Constants.TAG_PLAYER)
        {
            Destroy(gameObject);
        }
    }
}
