//using Microsoft.Unity.VisualStudio.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateProfile : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeSprite(Sprite newSprite)
    {
        if (spriteRenderer != null && newSprite != null)
        {
            spriteRenderer.sprite = newSprite;
            return;
        }
        else if(this.gameObject.GetComponent<UnityEngine.UI.Image>().sprite != null)
        {
            this.gameObject.GetComponent<UnityEngine.UI.Image>().sprite = newSprite;
        }
    }
}
