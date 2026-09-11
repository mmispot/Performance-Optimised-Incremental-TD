using UnityEngine;
using System.Collections;
using System;

public class BaseEnemy : MonoBehaviour
{
    private Transform[] pathPoints;

    [SerializeField] private float moveSpeed = 5f;

    public event Action<BaseEnemy> OnDespawn;

    public void Activate(Vector3 spawnPosition, Transform[] path)
    {
        pathPoints = path;
        transform.position = spawnPosition;
        gameObject.SetActive(true);
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        foreach (Transform targetPoint in pathPoints)
        {
            while (Vector3.Distance(transform.position, targetPoint.position) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, moveSpeed * Time.deltaTime);
                yield return null;
            }
        }

        DeSpawn();
    }

    private void DeSpawn()
    {
        OnDespawn?.Invoke(this);
        Destroy(gameObject);
    }
}