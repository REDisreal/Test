using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardRandomizer : MonoBehaviour
{
    public Sprite[] logoSprites;

    void Start()
    {
        int cardCount = transform.childCount;
        int pairCount = cardCount / 2;

        List<Sprite> pool = new List<Sprite>(logoSprites);
        List<Sprite> deck = new List<Sprite>();

        for (int i = 0; i < pairCount; i++)
        {
            int index = Random.Range(0, pool.Count);
            deck.Add(pool[index]);
            deck.Add(pool[index]);
            pool.RemoveAt(index);
        }

        for (int i = 0; i < deck.Count; i++)
        {
            int j = Random.Range(i, deck.Count);
            Sprite temp = deck[i];
            deck[i] = deck[j];
            deck[j] = temp;
        }

        for (int i = 0; i < cardCount; i++)
        {
            Image logo = transform.GetChild(i).Find("Front/Logo").GetComponent<Image>();
            logo.sprite = deck[i];
        }
    }
}