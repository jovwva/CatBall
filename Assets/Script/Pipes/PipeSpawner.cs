using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [Header("Pipe information")]
    [SerializeField] private GameObject ballRef;
    [SerializeField] private float      spawnDelay = 5f;

    [Space]
    [SerializeField] private float timer = 0;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnDelay)
        {
            timer = 0;
            CreateBall();
        }
    }

    private void CreateBall()
    {
        Instantiate(ballRef, transform.position, Quaternion.identity);
    }
}
