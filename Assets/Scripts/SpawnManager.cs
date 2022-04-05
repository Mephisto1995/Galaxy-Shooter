using System.Collections;
using UnityEngine;
using Utils;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _powerShotPrefab;

    [SerializeField] private GameObject _enemyContainer;
    [SerializeField] private GameObject _powerShotContainer;

    private bool _canSpawnPrefab = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnTripleShotPowerupRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (_canSpawnPrefab)
        {
            AddObjectToContainer(GetSpawnItemRandomOnMap(_enemyPrefab), _enemyContainer);
            yield return new WaitForSeconds(1.0f);
        }
    }

    IEnumerator SpawnTripleShotPowerupRoutine()
    {
        while(_canSpawnPrefab)
        {
            AddObjectToContainer(GetSpawnItemRandomOnMap(_powerShotPrefab), _powerShotContainer);
            yield return new WaitForSeconds(Random.Range(3, 8));
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
        _canSpawnPrefab = status;
    }
}
