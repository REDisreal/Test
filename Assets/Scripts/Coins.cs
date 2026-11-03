using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] private int giatridongxu=1;
    [SerializeField] private Vector2 vitrinhonhat=new Vector2(-8,-4);
    [SerializeField] private Vector2 vitrilonnhat=new Vector2(8,4);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.AddCoin(giatridongxu);
            dichchuyenvitri();
        }
    }

    private void dichchuyenvitri()
    {
        float x = Random.Range(vitrinhonhat.x, vitrilonnhat.x);
        float y = Random.Range(vitrinhonhat.y, vitrilonnhat.y);
        transform.position = new Vector2(x, y);
    }
}
