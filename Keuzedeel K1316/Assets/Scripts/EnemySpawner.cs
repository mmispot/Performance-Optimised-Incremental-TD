using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform[] pathPoints;

    private readonly List<BaseEnemy> activeEnemies = new List<BaseEnemy>();
    // pool removed — no longer reusing enemies

    public void SpawnWave(int amount, float delayBetweenSpawns)
    {
        StartCoroutine(SpawnWaveRoutine(amount, delayBetweenSpawns));
    }

    private IEnumerator SpawnWaveRoutine(int amount, float delayBetweenSpawns)
    {
        for (int i = 0; i < amount; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(delayBetweenSpawns);
        }
    }

    private BaseEnemy SpawnEnemy()
    {
        GameObject obj = Instantiate(enemyPrefab);
        BaseEnemy enemy = obj.GetComponent<BaseEnemy>();
        enemy.OnDespawn += HandleEnemyDespawn;

        activeEnemies.Add(enemy);
        enemy.Activate(spawnPoint.position, pathPoints);

        return enemy;
    }

    private void HandleEnemyDespawn(BaseEnemy enemy)
    {
        activeEnemies.Remove(enemy); // just tracking who's alive now, no re-queueing
    }
}