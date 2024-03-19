using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;

[CreateAssetMenu(fileName = "GameInformation", menuName = "ScriptableObjects/GameInformation", order = 1)]
public class GameInfo : ScriptableObject
{
    [SerializeField]
    public string playerID;
    public string uid;
    public int avatar;
    public string referralLink;
    public string referralCode;
    public DateTime updatedAt;
    public string userToken;
    public string userName;
    public string balance;
    public string account;
    public string operatorToken;
    public string address;
    //public SerializedDictionary<int, int> Amount = new SerializedDictionary<int, int>();
    public bool unAuthorized;
    public string encodedAuthToken;

    [ContextMenu("DeleteData")]
    public void DeleteData()
    {
        playerID = "";
        uid = "";
        avatar = 0;
        referralCode = "";
        referralLink = "";
        updatedAt = new DateTime();
        userToken = "";
        userName = "";
        balance = "";
        account = "";
        operatorToken = "";
        unAuthorized = false;
        encodedAuthToken = "";
    }
    
}
