using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    private float _playerWidth;
    private float _playerHeight;
    private Vector3 _screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        _playerWidth = transform.GetComponent<MeshRenderer>().bounds.size.x / 2 + +0.5f;
        _playerHeight = transform.GetComponent<MeshRenderer>().bounds.size.y / 2 + +0.5f;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPosition = transform.position;
        viewPosition.x = Mathf.Clamp(viewPosition.x, _screenBounds.x + _playerWidth, _screenBounds.x * -1 - _playerWidth);
        viewPosition.y = Mathf.Clamp(viewPosition.y, _screenBounds.y + _playerHeight, _screenBounds.x * -1 - _playerHeight);
        transform.position = viewPosition;
    }
}
