using UnityEngine;
using System.Collections;

public class BaseEnemy : MonoBehaviour
{
    public Transform[] pathPoints;
    public Transform spawner;

    [SerializeField] private float moveSpeed = 5f;

    private void Start()
    {
        SpawnIn();
    }

    private void SpawnIn()
    {
        transform.position = spawner.position;
        gameObject.SetActive(true);

        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        foreach (Transform targetPoint in pathPoints) // loop through each point in the path (transforms in scene)
        {
            while (Vector3.Distance(transform.position, targetPoint.position) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, moveSpeed * Time.deltaTime);
                yield return null;
            }
        }

        if (Vector3.Distance(transform.position, pathPoints[10].position) < 0.01f)
        {
            DeSpawn();
        }    
    }

    private void DeSpawn()
    {
        Debug.Log("Enemy reached the end of the path and is despawning.");
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
