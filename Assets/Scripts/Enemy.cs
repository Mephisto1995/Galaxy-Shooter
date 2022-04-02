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
    }

    private void MoveEnemy()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < Constants.CAMERA_DOWN_POINT)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        float rng = Random.Range(Constants.CAMERA_LEFT_POINT, Constants.CAMERA_RIGHT_POINT);
        transform.position = new Vector3(rng, Constants.CAMERA_UPPER_POINT, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Constants.TAG_LASER || other.tag == Constants.TAG_PLAYER)
        {
            Destroy(gameObject);
        }
    }
}
