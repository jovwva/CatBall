using UnityEngine;
using TMPro;

public class StartManager : MonoBehaviour
{
    public GameObject ballsPrefab;
    public float timeSpawn = 2f;
    private float timer;
    [SerializeField]
    public int count = 0;
    private bool stop;
    [SerializeField] private TMP_Text textMeshPro;
    [SerializeField] private GameObject finishPanel; 

    private void Start()
    {
        
        timer = timeSpawn;
        UpdateCountText(); 
    }

    private void UpdateCountText()
    {
        textMeshPro.text = "Count: " + count; 
    }

    private void Update()
    {
        if (!stop)
            Spawn();
    }

    private void Spawn()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = timeSpawn;
            Instantiate(ballsPrefab, transform);
            UpdateCount();
        }
    }
    private void UpdateCount()
    {
        count--;
        if (count <= 0)
        {
            stop = true;
        }
        UpdateCountText();
    }

    


}