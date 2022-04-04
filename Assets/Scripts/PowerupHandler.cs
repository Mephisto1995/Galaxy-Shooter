using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class PowerupHandler : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _powerupDuration = 5f;

    private bool _isPowerupActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector2.down * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == Constants.TAG_PLAYER)
        {
            ActivateTripleShotPowerup();
            Destroy(gameObject);
        }
    }

    private Player GetPlayerReference()
    {
        return GameObject.Find(nameof(Player)).GetComponent<Player>();
    }

    private void ActivateTripleShotPowerup()
    {
        //Debug.LogWarning(nameof(ActivateTripleShotPowerup));

        Player player = GetPlayerReference();

        if (player != null) 
        {
            player.SetPowerupDuration(_powerupDuration);
            player.ActivatePowerup();
            _isPowerupActive = true;
        }
    }

    //private void DeactivateTripleShotPowerup()
    //{
    //    Debug.Log(nameof(DeactivateTripleShotPowerup));
    //    Player player = GetPlayerReference();

    //    if (player != null)
    //    {
    //        Debug.LogError("Player found");
    //        player.DeactivatePowerup();
    //        _isPowerupActive = false;
    //    }
    //}
}
