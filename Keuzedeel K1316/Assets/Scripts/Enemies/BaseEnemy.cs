using UnityEngine;
using System.Collections;
using System;
using Unity.Collections.Tests.CoreCLR.TestJobs;

public class BaseEnemy : MonoBehaviour
{

    //Base Enemy stats

    [SerializeField] protected int health = 100;
    [SerializeField] protected int damage = 10;

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
        //voordat het object despawned, zorgen dat damage wordt genomen van total "player" health

        OnDespawn?.Invoke(this);
        Destroy(gameObject);
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            DeSpawn();
        }
    }
}