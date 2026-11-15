using UnityEngine;

public class MagicCoins : MonoBehaviour
{
    [SerializeField] private int giatridongxu=1;
    [SerializeField] private int soluongcan=40;
    [SerializeField] private float hesophongto = 1.1f;
    [SerializeField] private Vector2 vitrinhonhat=new Vector2(-8,-4);
    [SerializeField] private Vector2 vitrilonnhat=new Vector2(8,4);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.AddCoin(giatridongxu);
            if (GameManager.Instance.CoinCount >= soluongcan)
            {
                Debug.Log("Bạn đã thắng!");
                Destroy(collision.gameObject);
                return;
            }
            biendoinhanvat(collision);
            dichchuyenvitri();
        }
    }

    private void biendoinhanvat(Collider2D nhanVat)
    {
        nhanVat.transform.localScale *= hesophongto;
        nhanVat.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
    }
    private void dichchuyenvitri()
    {
        float x = Random.Range(vitrinhonhat.x, vitrilonnhat.x);
        float y = Random.Range(vitrinhonhat.y, vitrilonnhat.y);
        transform.position = new Vector2(x, y);
    }
}
