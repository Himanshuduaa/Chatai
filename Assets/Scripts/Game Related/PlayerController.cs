using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour, IPlayer
{
    [SerializeField] TextMeshProUGUI nameOfPlayer;
    [SerializeField] TextMeshProUGUI pointsOfPlayer;
    [SerializeField] GameObject Dealer;
    [SerializeField] Image playerDP;
    public List<Card> _playerCards;
    public List<Card> playerCards
    {
        get { return _playerCards; }
        set
        {
            _playerCards = value;
            Debug.Log("Something is changed");
            OnPlayerCardsChanged?.Invoke();
        }
    }
    public Transform cardsContainer;
    public PlayerType playerType;
    public event Action<int> ScoreChanged;
    public string PlayerName { get; private set; }
    public int Score { get; private set; }
    // Event to notify listeners when playerCards change
    public event System.Action OnPlayerCardsChanged;

    // Example method that modifies playerCards
    public void AddCard(Card newCard)
    {
        playerCards.Add(newCard);
    }

    // Example method that removes a card from playerCards
    public void RemoveCard(Card cardToRemove)
    {
        playerCards.Remove(cardToRemove);
    }

    // Example method that clears playerCards
    public void ClearCards()
    {
        playerCards.Clear();
    }
    // Start is called before the first frame update
    void Start()
    {
        // Subscribe to the card changed event for each card
        foreach (var card in playerCards)
        {
            card.OnCardChanged += HandleCardChanged;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Event handler for card changes
    void HandleCardChanged(Card card, int index)
    {
        Debug.Log("Card changed: " + card.index);
        // Perform necessary actions when a card changes
    }
    // Example method to handle the event
    private void HandlePlayerCardsChanged(object sender, PlayerCardsChangedEventArgs args)
    {
        if (args != null)
        {
            if (args.Type == PlayerCardsChangedEventArgs.ChangeType.Add)
            {
                Debug.Log("Card added at index " + args.Index + ": " + args.ChangedCard);
            }
            else if (args.Type == PlayerCardsChangedEventArgs.ChangeType.Remove)
            {
                Debug.Log("Card removed at index " + args.Index + ": " + args.ChangedCard);
            }
        }
        else
        {
            Debug.Log("Player cards have been changed.");
        }
    }
    public void setMyCrds()
    {
        GameObject Cards;
        for (int i = 0; i < 4; i++)
        {
            if (playerType == PlayerType.local)
            {
                Cards = Instantiate(UIManagerGameBoard.Instance.gameUI.cardsPrefab, new Vector3(0f * 1.3f, 0f, 0f), Quaternion.identity, cardsContainer);
                Cards.transform.localPosition = new Vector3(i * 1.3f, 0f, 0f);
            }
            else
            {
                Cards = Instantiate(UIManagerGameBoard.Instance.gameUI.cardsPrefab, new Vector3(0f * 0.8f, 0f, 0f), Quaternion.identity, cardsContainer);
                Cards.transform.localPosition = new Vector3(i * 0.8f, 0f, 0f);
            }
            playerCards.Add(Cards.GetComponent<Card>());
        }
    }
    public Vector3 getCardPos(int cardNo)
    {
        Vector3 pos=new Vector3();
        if (playerType == PlayerType.local)
        {
            pos=new Vector3(cardNo * 1.3f, 0f, 0f);
            return pos;
        }
        else
        {
            pos = new Vector3(cardNo * 0.8f, 0f, 0f);
            return pos;
        }
    }
    // Method to initialize player data
    public void Initialize(string name)
    {
        PlayerName = name;
        Score = 0;
    }

    public void IncreaseScore(int points)
    {
        throw new NotImplementedException();
    }

    public void SetSprite(Sprite sprite)
    {
        throw new NotImplementedException();
    }
}
public enum PlayerType
{
    local,other
}
// Define a custom event argument class to hold change information
public class PlayerCardsChangedEventArgs : EventArgs
{
    public enum ChangeType
    {
        Add,
        Remove
    }

    public ChangeType Type { get; private set; }
    public int Index { get; private set; }
    public Card ChangedCard { get; private set; }

    public PlayerCardsChangedEventArgs(ChangeType type, int index, Card changedCard)
    {
        Type = type;
        Index = index;
        ChangedCard = changedCard;
    }
}
