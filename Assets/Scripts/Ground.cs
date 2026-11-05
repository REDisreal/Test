using UnityEngine;

public class Ground : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        Time.timeScale = 0f;
        Debug.Log("Bạn đã thua");
    }
}