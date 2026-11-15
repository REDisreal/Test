using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    private TMP_Text diem;

    private void Awake()
    {
        diem = GetComponent<TMP_Text>();
        Point.ResetPoint();
    }

    private void Update()
    {
        diem.text = "Score: " + Point.Tongdiem;
    }
}