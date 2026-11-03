using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private int giatridongxu = 0;

    public int CoinCount => giatridongxu;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCoin(int amount)
    {
        giatridongxu += amount;
        Debug.Log($"[CoinManager] Đã thu thập {amount} coin! Tổng cộng: {giatridongxu}");
    }
}