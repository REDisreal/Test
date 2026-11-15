using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IPointerClickHandler
{
    public bool isFlipped;
    Animator animator;
    CardManager manager;

    void Start()
    {
        animator = GetComponent<Animator>();
        manager = GetComponentInParent<CardManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isFlipped || manager.isChecking) return;
        Flip();
        manager.CardFlipped(this);
    }

    public void Flip()
    {
        animator.SetTrigger("Flip");
        isFlipped = !isFlipped;
    }

    public Sprite GetLogo()
    {
        return transform.Find("Front/Logo").GetComponent<Image>().sprite;
    }
}