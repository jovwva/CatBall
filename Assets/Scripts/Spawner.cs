using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float timeSpawn = 2f;
    private float timer;

    private void Start()
    {
        timer = timeSpawn;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = timeSpawn;
            Instantiate(enemyPrefab, transform);
        }
    }
}