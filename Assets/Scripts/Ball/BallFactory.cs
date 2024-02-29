using UnityEngine;

public class BallFactory : MonoBehaviour
{
    public GameObject   ballPref;
    public int          ballSpawned = 0;
    public int          ballLimit   = 20;
    public float        spawnDelay  = .4f;

    public bool         factoryState = true;

    private float timer = 0;

    private void Update()
    {
        if (!factoryState) {
            return;
        }
        timer += Time.deltaTime; 

        if (timer >= spawnDelay) {
            timer = 0f;
            Instantiate(ballPref, transform.position, Quaternion.identity);
            ballSpawned++;
        }
        if (ballSpawned >= ballLimit) {
            factoryState = false;
        }
    }
}
