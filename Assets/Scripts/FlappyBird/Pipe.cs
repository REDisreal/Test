    using UnityEngine;
using UnityEngine.SceneManagement;

public class Pipe : MonoBehaviour
{
    public static Pipe Instance;
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private float minY = -1f;
    [SerializeField] private float maxY = 2f;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject scoreDisplay;
    [SerializeField] private AudioClip tiengThua;

    private void Awake()
    {
        gameOverPanel.SetActive(false);
        Instance = this;
    }

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
    public void GameOver()
    {
        AudioSource.PlayClipAtPoint(tiengThua, Camera.main.transform.position);
        Time.timeScale = 0f;
        scoreDisplay.SetActive(false);  
        gameOverPanel.SetActive(true);
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }     
}