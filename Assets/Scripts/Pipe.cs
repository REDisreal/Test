using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private float minY = -1f;
    [SerializeField] private float maxY = 2f;

    public void StartSpawning()
    {
        InvokeRepeating(nameof(SpawnPipe), 0f, spawnInterval);
    }

    private void SpawnPipe()
    {
        float y = Random.Range(minY, maxY);
        Vector3 pos = new Vector3(transform.position.x, y, 0f);
        Instantiate(pipePrefab, pos, Quaternion.identity);
    }
}