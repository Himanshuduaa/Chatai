using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerGameBoard : MonoBehaviour
{
    public static UIManagerGameBoard Instance;
    public GameUI gameUI;   
    public Transform PlayersPosition;
    //public GameObject cards;
    //public GameObject playerPrefab;
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(Instance);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
