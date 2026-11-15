using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class ClubInfo
{
    public Sprite logo;
    [TextArea] public string description;
}

public class CardManager : MonoBehaviour
{
    public bool isChecking;
    public ClubInfo[] clubs;
    public GameObject itemPrefab;
    public Transform content;
    Card firstCard;

    public void CardFlipped(Card card)
    {
        if (firstCard == null)
        {
            firstCard = card;
            return;
        }

        StartCoroutine(CheckPair(firstCard, card));
        firstCard = null;
    }

    IEnumerator CheckPair(Card a, Card b)
    {
        isChecking = true;
        yield return new WaitForSeconds(1f);

        if (a.GetLogo() != b.GetLogo())
        {
            a.Flip();
            b.Flip();
        }
        else
        {
            ShowKnowledge(a.GetLogo());
        }

        isChecking = false;
    }

    void ShowKnowledge(Sprite logo)
    {
        GameObject item = Instantiate(itemPrefab, content);
        item.transform.Find("Logo").GetComponent<Image>().sprite = logo;

        string text = logo.name;
        foreach (ClubInfo club in clubs)
        {
            if (club.logo == logo) text = club.description;
        }
        item.GetComponentInChildren<TextMeshProUGUI>().text = text;
    }
}