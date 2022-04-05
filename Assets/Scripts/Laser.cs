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

    private void DestroyLaserObject()
    {
        if (transform.position.y > Constants.CAMERA_UPPER_POINT)
        {
            if (transform.parent)
            {
                Destroy(transform.parent.gameObject);
            }

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Constants.TAG_ENEMY)
        {
            Destroy(gameObject);
        }
    }
}
