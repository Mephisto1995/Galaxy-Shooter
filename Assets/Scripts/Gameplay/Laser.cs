using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class Laser : MonoBehaviour
{
    [SerializeField] private float _speed;

    void Update()
    {
        MoveUp();
        DestroyLaserObjectOutOfBounds();
    }

    private void MoveUp()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
    }

    private void DestroyLaserObjectOutOfBounds()
    {
        if (transform.position.y > Constants.CAMERA_UPPER_POINT)
        {
            // destroying triple shot prefab
            if (transform.parent)
            {
                Destroy(transform.parent.gameObject);
            }

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        //Debug.LogWarning(collision.tag +" "+ collision.gameObject.name);
        /*Enemy enemy = collision.GetComponent<Enemy>();
        if (collision.tag == Constants.TAG_EXPLOSION)
        {
            
            return;
        }

        if (enemy)
        {
            Debug.Log("Animation in progress status: " + enemy.GetEnemyShipAnimationInProgress());
        }

        // if we're during the animation sequence, don't destroy the laser
        if (collision.tag == Constants.TAG_ENEMY && enemy && enemy.GetEnemyShipAnimationInProgress())
        {
            return;
        }*/

        if (collision.tag == Constants.TAG_ENEMY)
        {
            Destroy(gameObject);
        }

    }
}
