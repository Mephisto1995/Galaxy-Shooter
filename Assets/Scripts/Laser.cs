using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float mSpeed;
    
    // Update is called once per frame
    void Update()
    {
        Instantiate();
        DestroyLaserObject();
    }

    private void Instantiate()
    {
        transform.Translate(Vector3.up * mSpeed * Time.deltaTime);
    }

    private void DestroyLaserObject()
    {
        const float DESTROY_DELAY = 1f;
        Destroy(gameObject, DESTROY_DELAY);
    }
}
