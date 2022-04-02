using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class Laser : MonoBehaviour
{
    [SerializeField] private float _speed;
    
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
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Constants.TAG_ENEMY)
        {
            Destroy(gameObject);
        }
    }
}
