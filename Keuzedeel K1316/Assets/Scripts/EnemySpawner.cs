using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float delayTimer = 0.1f;

    public IEnumerator Spawn(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Instantiate(
                enemyPrefab,
                transform.position,
                Quaternion.identity
            );

            yield return new WaitForSeconds(delayTimer);
        }
    }

    public void StartSpawning(int amount)
    {
        StartCoroutine(Spawn(amount));
    }
}
