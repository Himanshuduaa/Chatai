using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBoardManager : MonoBehaviour
{
    public static CardBoardManager instance;
    [SerializeField] SerializedDictionary <int, List<DropZone>> CardDrop =new SerializedDictionary<int, List<DropZone>> ();
    [SerializeField] List<DropZone> dropZones = new List<DropZone> ();
    [SerializeField] GameObject DropZonePrefab;
    [SerializeField] Transform dropZoneContainer;
    [SerializeField] float offsetXDrop;
    [SerializeField] float offsetYDrop;
    public PlayersManager players;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0;i<5;i++)
        {
            List<DropZone> dropZone = new List<DropZone>();
            for (int j = 0; j < 8; j++)
            {
                GameObject drop = Instantiate(DropZonePrefab, new Vector3(0f * offsetXDrop, i* offsetYDrop, 0f), Quaternion.identity, dropZoneContainer);
                drop.transform.localPosition = new Vector3(j * offsetXDrop, i* offsetYDrop, 0f);
                dropZone.Add(drop.gameObject.GetComponent<DropZone>());
            }
            CardDrop.Add(i+1, dropZone);
        }
        players.localPlayerCards();
        players.setAllPlayers();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
