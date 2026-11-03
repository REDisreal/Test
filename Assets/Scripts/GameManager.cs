using UnityEngine;
using TMPro;
using System.Xml.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private int soluongdongxu = 0;
    [SerializeField] private TMP_Text textSoXu;

    public int CoinCount => soluongdongxu;

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
    private void Start()
    {
        capnhatUI();
    }

    public void AddCoin(int amount)
    {
        soluongdongxu += amount;
        Debug.Log($"Đã thu thập {amount} xu! Tổng cộng: {soluongdongxu}");
        capnhatUI();
    }
    private void capnhatUI()
    {
        textSoXu.text="Xu: " + soluongdongxu;
    }
}