using System.Collections;
using UnityEngine;
using Utils;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemyContainer;
    [SerializeField] private GameObject _powerupContainer;

    [SerializeField] private GameObject[] _enemies;
    [SerializeField] private GameObject[] _powerUps;

    private bool _isPlayerDead = false;

    private void Start()
    {
        StartSpawning();
    }

    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnRandomPowerup());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        yield return new WaitForSeconds(Constants.SPAWN_DELAY);
        int randomEnemy = Random.Range(0, _enemies.Length);
        AddObjectToContainer(GetSpawnItemRandomOnMap(_enemies[randomEnemy]), _enemyContainer);
        yield return new WaitForSeconds(1.0f);

        if (_isPlayerDead)
        {
            yield return null;
        }
    }

    IEnumerator SpawnRandomPowerup()
    {
        yield return new WaitForSeconds(Constants.SPAWN_DELAY);
        int randomPowerup = Random.Range(0, _powerUps.Length);
        AddObjectToContainer(GetSpawnItemRandomOnMap(_powerUps[randomPowerup]), _powerupContainer);
        yield return new WaitForSeconds(Random.Range(Constants.POWERUP_COOLDOWN_SPAWN_RANGE_LOW, Constants.POWERUP_COOLDOWN_SPAWN_RANGE_HIGH));


        if (_isPlayerDead)
        {
            yield return null;
        }
    }

    private GameObject GetSpawnItemRandomOnMap(GameObject prefab)
    {
        float rng = Random.Range(Constants.CAMERA_LEFT_POINT, Constants.CAMERA_RIGHT_POINT);
        Vector3 position = new Vector3(rng, Constants.CAMERA_UPPER_POINT, 0);

        return Instantiate(prefab, position, Quaternion.identity);
    }

    private void AddObjectToContainer(GameObject gameObject, GameObject container)
    {
        gameObject.transform.parent = container.transform;
    }

    public void PlayerStatus(bool status)
    {
        _isPlayerDead = status;
    }
}
