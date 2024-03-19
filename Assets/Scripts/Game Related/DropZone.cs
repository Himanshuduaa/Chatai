using DG.Tweening;
using SpriteGlow;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Card;

public class DropZone : MonoBehaviour,IDrop
{
    [SerializeField] private BoxCollider2D dropCollider;
    [SerializeField] private bool cardDropped;
    [SerializeField] private int cardNo;
    public int setCardNo
    {
        get { return cardNo; }
        set
        {
            cardNo = value;
        }
    }
    public int coordinates => throw new System.NotImplementedException();

    // Start is called before the first frame update
    void Start()
    {
        dropCollider = GetComponent<BoxCollider2D>();
        this.gameObject.GetComponent<SpriteGlowEffect>().enabled = false;
        Destroy(GetComponent<CardObject>());
        dropCollider.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    public void OnDrop(GameObject gb)
    {
        gb.transform.DOMove(transform.position, 0.15f);
        gb.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine(moved(gb));
        
    }
    IEnumerator moved(GameObject gb)
    {
        yield return new WaitForSeconds(0.15f);
        gb.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        gb.gameObject.GetComponent<CardObject>().enabled = false;
        gb.transform.position = dropCollider.transform.position;
        GetComponent<SpriteGlowEffect>().enabled = false;
        gb.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        gb.GetComponent<SpriteRenderer>().sortingOrder = 3;
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gb.gameObject.transform.position = transform.position;
        GetComponent<SpriteRenderer>().sprite = gb.gameObject.GetComponent<SpriteRenderer>().sprite;
        GetComponent<SpriteRenderer>().color = Color.white;
        this.gameObject.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        gb.SetActive(false);
        gb.transform.localPosition = Vector3.zero;
        gb.GetComponent<CardObject>().IsActive = false;
        cardDropped = true;
    }
}
