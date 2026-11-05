using UnityEngine;

public class PipeMove : MonoBehaviour
{
    public float speed = 2f;
    public float destroyX = -15f;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }
}