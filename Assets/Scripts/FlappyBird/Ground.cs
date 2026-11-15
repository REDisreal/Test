using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.SetActive(false);
        Pipe.Instance.GameOver();
    }
}