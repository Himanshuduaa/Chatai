using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class AmountSelection : MonoBehaviour
{
    [SerializedDictionary("Amount","Win")]
    public SerializedDictionary <int,int> Amount=new SerializedDictionary<int,int>();
    public TextMeshProUGUI Bet;
    public TextMeshProUGUI Wins;
    public int index = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        BetData betdata=new BetData();
        List<int> list = new List<int>();
        list.Add(20);
        list.Add(40);
        list.Add(100);
        list.Add(200);
        list.Add(500);
        betdata.WinPercent = 5;
        betdata.BetAmountsArr = list;
        setBets(betdata);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setBets(BetData betdata)
    {
        for (int i = 0; i < betdata.BetAmountsArr.Count; i++)
        {
            int totalAmount = CalculateTotalAmount(betdata.BetAmountsArr[i], betdata.WinPercent);
            if (!Amount.ContainsKey(betdata.BetAmountsArr[i])) 
            Amount.Add(betdata.BetAmountsArr[i], totalAmount);
        }
        setBetsUI();
    }
    public void setBetsUI()
    {
        Debug.Log("SettingBetsUI");
        Bet.text = Amount.ElementAt(index).Key.ToString();
        Wins.text = Amount.ElementAt(index).Value.ToString();
    }
    private int CalculateTotalAmount(int betAmount, int winPercentage)
    {
        // Calculate total amount as (bet amount * (1 + win percentage / 100))
        int totalAmount = betAmount * (1 + winPercentage / 100);
        return totalAmount;
    }
    public void IncrementBet()
    {
        if(index<Amount.Count-1 && index>=0)
        {
            index = index +1;
            Debug.LogWarning("index is " + index+" and count of dictionary is "+ Amount.Count);
            Bet.text = Amount.ElementAt(index).Key.ToString();
            Wins.text = Amount.ElementAt(index).Value.ToString();
        }
    }
    public void DecrementBet()
    {
        Debug.LogWarning("index is " + index + " and count of dictionary is " + Amount.Count);
        if (index <= Amount.Count-1 && index>0)
        {
            Debug.LogWarning("Decrementing");
            index = index - 1;
            Bet.text = Amount.ElementAt(index).Key.ToString();
            Wins.text = Amount.ElementAt(index).Value.ToString();
        }
    }
}
