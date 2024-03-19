using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;

[CreateAssetMenu(fileName = "GameUI", menuName = "ScriptableObjects/GameUI", order = 1)]
public class GameUI : ScriptableObject
{
    [Header("0-12 ===== Club Series")]
    [Header("13-25 ===== Diamond Series")]
    [Header("26-38 ===== Heart Series")]
    [Header("39-51 ===== Spade Series")]
    [SerializeField]
    public List<Sprite> cards=new List<Sprite> ();
    public Sprite backCard;
    public Sprite cardBGBoard;
    public GameObject cardsPrefab;
    public GameObject playerPrefab;
    public GameObject avatarSelectionPrefab;
    public List<Sprite> avatars = new List<Sprite>();
    public Sprite activatedAvatar;

    [ContextMenu("DeleteData")]
    public void DeleteData()
    {
        
    }
    public void getAvatars()
    {
        string folderPath = Application.dataPath + "/Resources/Avatars/";
        string[] filePaths = Directory.GetFiles(folderPath, "*.png", SearchOption.TopDirectoryOnly);

        // Sort file paths based on their numeric part (assumes naming convention like 1.png, 2.png, 3.png, ...)
        Array.Sort(filePaths, (a, b) => {
            string fileNameA = Path.GetFileNameWithoutExtension(a);
            string fileNameB = Path.GetFileNameWithoutExtension(b);
            int numberA, numberB;
            if (int.TryParse(fileNameA, out numberA) && int.TryParse(fileNameB, out numberB))
            {
                return numberA.CompareTo(numberB);
            }
            return fileNameA.CompareTo(fileNameB);
        });

        foreach (string filePath in filePaths)
        {
            string fileName = Path.GetFileNameWithoutExtension(filePath);
            Sprite sprite = Resources.Load<Sprite>("Avatars/" + fileName);
            if (sprite != null && !avatars.Contains(sprite)) // Check if sprite is not already in the list
            {
                avatars.Add(sprite);
            }
            else if (sprite == null)
            {
                Debug.LogWarning("Sprite loading failed for: " + fileName);
            }
        }

        Debug.Log("Total number of unique sprites loaded: " + avatars.Count);
    }
}
