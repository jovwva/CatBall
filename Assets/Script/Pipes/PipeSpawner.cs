using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [Header("Pipe information")]
    [SerializeField] private GameObject ballRef;
    [SerializeField] private float      spawnDelay = 5f;
    [SerializeField] private int        ballCount = 7;
    [Space]

    [Header("Link")]
    [SerializeField] private LevelManager levelManager;
    [Space]

    [SerializeField] private float timer = 0;
    [SerializeField] private bool  pipeState = true;



    private void Update()
    {
        if (!pipeState) 
        {
            this.enabled = false;
            return;
        }

        timer += Time.deltaTime;
        if (timer > spawnDelay)
        {
            timer = 0;
            CreateBall();
        }
    }

    private void CreateBall()
    {
        ballCount--;
        Instantiate(ballRef, transform.position, Quaternion.identity);

        if (ballCount <= 0)
        {
            levelManager.OutOfBall();
            pipeState = false;
        }
    }
}
