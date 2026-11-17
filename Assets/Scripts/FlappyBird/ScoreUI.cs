using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private Sprite[] soSprites;
    [SerializeField] private Image mauChuSo;

    private int diemCu = -1;

    private void Awake()
    {
        Point.ResetPoint();
        mauChuSo.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Point.Tongdiem != diemCu)
        {
            diemCu = Point.Tongdiem;
            CapNhat(diemCu);
        }
    }

    private void CapNhat(int diem)
    {
        foreach (Transform con in transform)
        {
            if (con != mauChuSo.transform)
            {
                Destroy(con.gameObject);
            }
        }

        foreach (char c in diem.ToString())
        {
            Image so = Instantiate(mauChuSo, transform);
            so.sprite = soSprites[c - '0'];
            so.gameObject.SetActive(true);
        }
    }
}