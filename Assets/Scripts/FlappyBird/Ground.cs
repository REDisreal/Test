using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] private AudioClip tiengVaDap;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(tiengVaDap, Camera.main.transform.position);
        //collision.gameObject.SetActive(false);
        Pipe.Instance.GameOver();
    }
}