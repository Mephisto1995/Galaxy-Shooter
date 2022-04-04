using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _enemyContainer;

    private bool _canSpawn = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (_canSpawn)
        {
            float rng = Random.Range(Constants.CAMERA_LEFT_POINT, Constants.CAMERA_RIGHT_POINT);
            Vector3 position = new Vector3(rng, Constants.CAMERA_UPPER_POINT, 0);

            GameObject enemyInstance = Instantiate(_enemyPrefab, position, Quaternion.identity);
            enemyInstance.transform.parent = _enemyContainer.transform;

            yield return new WaitForSeconds(1.0f);
        }
    }

    public void PlayerStatus(bool status)
    {
        _canSpawn = status;
    }
}
