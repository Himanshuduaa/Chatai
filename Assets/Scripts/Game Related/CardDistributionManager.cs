using SpriteGlow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class CardDistributionManager : MonoBehaviour
{
    public GameObject Deck;
    // Start is called before the first frame update
    void Start()
    {
        Deck.GetComponent<Button>().onClick.AddListener(clickedOnDeck);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void clickedOnDeck()
    {
        StartCoroutine(DistributeCards(4));
    }
    private void cardsActivate(bool val)
    {
        for (int i = 0; i < this.gameObject.GetComponent<CardBoardManager>().players.playerControllers.Count; i++)
        {
            for (int j = 0; j < this.gameObject.GetComponent<CardBoardManager>().players.playerControllers[i].playerCards.Count; j++)
            {
                GetComponent<CardBoardManager>().players.playerControllers[i].playerCards[j].card.gameObject.SetActive(val);
                GetComponent<CardBoardManager>().players.playerControllers[i].playerCards[j].card.IsActive = val;
                GetComponent<CardBoardManager>().players.playerControllers[i].playerCards[j].card.display(val);
                if(GetComponent<CardBoardManager>().players.playerControllers[i].playerType==PlayerType.local)
                {
                    GetComponent<CardBoardManager>().players.playerControllers[i].playerCards[j].card.IsMine = true;
                    GetComponent<CardBoardManager>().players.playerControllers[i].playerCards[j].card.IsLocked = false;
                }
                else
                {
                    GetComponent<CardBoardManager>().players.playerControllers[i].playerCards[j].card.IsMine = false;
                }
                GetComponent<CardBoardManager>().players.playerControllers[i].playerCards[j].card.transform.localPosition = Vector3.zero;
                GetComponent<CardBoardManager>().players.playerControllers[i].playerCards[j].card.IsActive = true;
            }
        }
    }
    IEnumerator DistributeCards(int noOfCards)
    {
        cardsActivate(false);
        List<GameObject> dummyCards = new List<GameObject>();
        var players = gameObject.GetComponent<CardBoardManager>().players.playerControllers;
        var deck = Deck.transform;

        for (int j = 0; j < noOfCards; j++) // Assuming you have 4 cards to distribute
        {
            for (int i = 0; i < players.Count; i++)
            {
                GameObject gb = Instantiate(UIManagerGameBoard.Instance.gameUI.cardsPrefab);
                gb.transform.position = deck.position;
                gb.transform.rotation = deck.rotation;
                gb.GetComponent<Card>().card.gameObject.SetActive(true);
                gb.GetComponent<Card>().card.GetComponent<SpriteRenderer>().sortingOrder = 2;
                gb.GetComponent<Card>().card.GetComponent<SpriteGlowEffect>().enabled = false;
                gb.GetComponent<Card>().card.GetComponent<SpriteRenderer>().sprite = UIManagerGameBoard.Instance.gameUI.backCard;
                gb.GetComponent<Card>().card.GetComponent<BoxCollider2D>().enabled = false;

                if (players[i].playerType == PlayerType.local)
                {
                    gb.transform.DOScale(players[i].playerCards[j].transform.localScale, 0.5f);
                    gb.transform.DOMove(players[i].playerCards[j].transform.position, 0.2f);
                }
                else
                {
                    gb.transform.DOScale(players[i].playerCards[j].transform.localScale - new Vector3(0.55f, 0.55f, 0.55f), 0.5f);
                    gb.transform.DOMove(players[i].playerCards[j].transform.position, 0.2f);
                }
                gb.GetComponent<Card>().index = j;
                gb.GetComponent<Card>().card.transform.localPosition=Vector3.zero;
                dummyCards.Add(gb);
                yield return new WaitForSeconds(0.2f);
            }
        }
        for (int i = 0; i < dummyCards.Count; i++)
        {
            Destroy(dummyCards[i].gameObject);
        }
        dummyCards.Clear();
        cardsActivate(true);
    }
}
