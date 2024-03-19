using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersManager : MonoBehaviour
{
    [SerializeField] PlayerController localPlayer;
    public List<PlayerController> playerControllers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setAllPlayers()
    {
        for(int i=0;i<3;i++)
        {
            GameObject player = Instantiate(UIManagerGameBoard.Instance.gameUI.playerPrefab, new Vector3(0f * 3.5f, 0f, 0f), Quaternion.identity, UIManagerGameBoard.Instance.PlayersPosition);
            player.transform.localPosition = new Vector3(i * 3.5f, 0f, 0f);
            player.GetComponent<PlayerController>().playerType = PlayerType.other;
            player.GetComponent<PlayerController>().setMyCrds();
            player.GetComponent<PlayerController>().OnPlayerCardsChanged += HandlePlayerCardsChanged;
            playerControllers.Add(player.GetComponent<PlayerController>());
        }
    }
    private void HandlePlayerCardsChanged()
    {
        Debug.Log("A player's cards changed.");
        // Perform any actions you want to take when a player's cards change
    }
    public void localPlayerCards()
    {
        localPlayer.setMyCrds();
        playerControllers.Add(localPlayer);
    }
}
