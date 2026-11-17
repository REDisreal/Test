using UnityEngine;

public class Point : MonoBehaviour
{
    private static int point = 0;
    public static int Tongdiem => point;
    [SerializeField] private AudioClip tiengDiem;

    public static void ResetPoint()
    {
        point = 0;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            point += 1;
            AudioSource.PlayClipAtPoint(tiengDiem, Camera.main.transform.position);
        }
    }
}