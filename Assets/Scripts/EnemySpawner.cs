using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private int _enemyToSpawnCount;
    [SerializeField] private float _timeBetweenSpawnLowerBound = 0.5f;
    [SerializeField] private float _timeBetweenSpawnUpperBound = 1.5f;
    private CooldownTimer _spawnTimer = new CooldownTimer();
    private float _timeBetweenSpawn;
    private int _enemiesRemainingCount;
    [SerializeField] private EnemiesRemainingUI _enemiesRemainingUI;

    public void DecrementEnemiesRemainingCount()
    {
        _enemiesRemainingCount--;
        _enemiesRemainingUI.UpdateEnemiesRemainingText(_enemiesRemainingCount);
        
        if (_enemiesRemainingCount == 0)
        {
            EndgameHandler.instance.Initialize(EndgameHandler.GameState.Win);
        }
    }

    private void Start()
    {
        _enemiesRemainingCount = _enemyToSpawnCount;
        _enemiesRemainingUI.UpdateEnemiesRemainingText(_enemiesRemainingCount);
    }

    private void Update()
    {
        if (_spawnTimer.CooldownComplete && _enemyToSpawnCount > 0)
        {
            _timeBetweenSpawn = Random.Range(_timeBetweenSpawnLowerBound, _timeBetweenSpawnUpperBound);
            _spawnTimer.cooldownAmount = _timeBetweenSpawn;
            GameObject enemyInstance = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            enemyInstance.GetComponent<EnemyHealth>().SetSpawner(this);
            _enemyToSpawnCount--;

            _spawnTimer.StartCooldown();
        }
    }
}
