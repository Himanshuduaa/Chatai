using AYellowpaper.SerializedCollections;
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager Instance;
    public GameInfo gameInfo;
    public GameUI gameUI;
    public Transform avatarSelectionScreen;
    public SerializedDictionary<TypeOfPanel, GameObject> panels = new SerializedDictionary<TypeOfPanel, GameObject>();

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        gameUI.getAvatars();
        addAvatarSelection();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void addAvatarSelection()
    {
        for (int i = 0; i < gameUI.avatars.Count; i++)
        {
            GameObject avatar = Instantiate(gameUI.avatarSelectionPrefab,avatarSelectionScreen);
            avatar.GetComponent<AvatarSelection>().avatar.sprite = gameUI.avatars[i];
            if(i==4)
            {
                avatar.GetComponent<AvatarSelection>()._isSelected = true;
            }
            else
            {
                avatar.GetComponent<AvatarSelection>()._isSelected = false;
            }
        }
    }

    // Function to add a panel to the dictionary
    public void AddPanel(TypeOfPanel typeOfPanel, GameObject panel)
    {
        if (!panels.ContainsKey(typeOfPanel))
        {
            panels.Add(typeOfPanel, panel);
            panel.SetActive(false); // Deactivate the panel initially
        }
        else
        {
            Debug.LogWarning("Panel with name " + typeOfPanel + " already exists in the dictionary.");
        }
    }

    // Function to show a panel by name
    public void SwitchPanel(string panel)
    {
        foreach (var kvp in panels)
        {
            if (kvp.Key.panelName == panel)
            {
                kvp.Value.SetActive(true); // Show the specified panel
                kvp.Value.gameObject.transform.localScale = new Vector3(0,0,0);
                kvp.Value.gameObject.transform.DOScale(new Vector3(1, 1, 1), 0.3f);
            }
            else
            {
                kvp.Value.gameObject.transform.DOScale(new Vector3(0,0,0), 0.3f);
            }
        }
    }
    public void Show(string panel)
    {
        foreach (var kvp in panels)
        {
            if (kvp.Key.panelName == panel)
            {
                kvp.Value.SetActive(true); // Show the specified panel
                kvp.Value.gameObject.transform.localScale = new Vector3(0, 0, 0);
                kvp.Value.gameObject.transform.DOScale(new Vector3(1, 1, 1), 0.3f);
            }
        }
    }
    public void loadGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}
[Serializable]
public class TypeOfPanel
{
    public bool subPanel;
    public string panelName;
}
