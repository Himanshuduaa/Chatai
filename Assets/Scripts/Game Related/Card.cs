using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpriteGlow;

public class Card : MonoBehaviour
{
    public CardObject card;
    public int index;
    public delegate void CardChangedHandler(Card card, int index);
    public event CardChangedHandler OnCardChanged;
    // Method to update the card object
    public void UpdateCard(CardObject newCard)
    {
        card = newCard;
        // Invoke the event when the card changes
        OnCardChanged?.Invoke(this, index);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void highlight(bool val)
    {
        card.GetComponent<SpriteGlowEffect>().enabled = false;
    }
    public void CardBack()
    {
        card.GetComponent<SpriteRenderer>().sprite = UIManagerGameBoard.Instance.gameUI.backCard;
        card.GetComponent<SpriteRenderer>().sortingOrder = 2;
        highlight(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered");
    }
}
