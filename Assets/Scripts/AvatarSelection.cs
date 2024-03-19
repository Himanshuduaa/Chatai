using Lean.Gui;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AvatarSelection : MonoBehaviour
{
    IPlayer player;
    public Image avatar;
    public UnityEvent<Sprite> OnPlayerSelect; // Event for player selection
    private Sprite selectedSprite; // Sprite of the selected player
    private bool selected;
    public bool _isSelected
    {
        get { return selected; }
        set
        {
            selected = value;
            if(selected)
            {
                this.gameObject.GetComponent<LeanToggle>().On = true;
                this.gameObject.GetComponent<LeanButton>().interactable = false;
                MainMenuManager.Instance.gameUI.activatedAvatar = avatar.sprite;
            }
            else
            {
                this.gameObject.GetComponent<LeanToggle>().On = false;
                this.gameObject.GetComponent<LeanButton>().interactable = true;
            }
        }
    }
    void Start()
    {
        
    }
    public void ChangeAllPlayerSprites()
    {
        _isSelected = true;
        Sprite selectedSprite= avatar.sprite;
        UpdateProfile[] players = FindObjectsOfType<UpdateProfile>();
        foreach (UpdateProfile player in players)
        {
            player.ChangeSprite(selectedSprite);
        }
    }
    public void isNotSelected()
    {
        _isSelected= false;
    }

    public void SelectPlayer(Sprite playerSprite)
    {
        selectedSprite = playerSprite;
        OnPlayerSelect.Invoke(selectedSprite); // Invoke event to notify other objects
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void setSprite()
    {
        player.SetSprite(avatar.sprite);
    }
}
