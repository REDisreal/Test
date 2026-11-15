using UnityEngine;

public class Point : MonoBehaviour
{
    private static int point = 0;
    public static int Tongdiem => point;

    public static void ResetPoint()
    {
        point = 0;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            point += 1;
        }
    }
}