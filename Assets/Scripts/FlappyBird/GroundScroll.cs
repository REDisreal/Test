using UnityEngine;

public class GroundScroll : MonoBehaviour
{
    public float speed = 2f;

    private float width;
    private float startX;

    private void Start()
    {
        width = GetComponent<SpriteRenderer>().bounds.size.x;
        startX = transform.position.x;
    }

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x <= startX - width)
        {
            transform.position += new Vector3(width * 2f, 0f, 0f);
        }
    }
}