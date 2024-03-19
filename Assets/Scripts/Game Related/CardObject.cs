using DG.Tweening;
using SpriteGlow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardObject : MonoBehaviour
{
    private bool active = false;
    EventTrigger eventTrigger;
    private IDrop dropLocation;
    private GameObject placeHolder;
    [SerializeField] bool Locked;
    
    public bool IsLocked
    {
        get { return Locked; }
        set
        {
            Locked = value;
            if(!Locked)
            {
                dropLocation = null;
            }
        }
    }
    private Vector3 myLocalScale;

    // Property to get and set the enabled state
    public bool IsActive
    {
        get { return active; }
        set
        {
            active = value;
            if(active)
            {
                GetComponent<CardObject>().enabled = active;
                GetComponent<SpriteGlowEffect>().enabled = false;
                GetComponent<SpriteRenderer>().sortingOrder = 2;
                transform.localPosition = Vector3.zero;
            }
            else
            {
                GetComponent<CardObject>().enabled = false;
                GetComponent<SpriteGlowEffect>().enabled = false;
                GetComponent<SpriteRenderer>().sortingOrder = 2;
            }
        }
    }
    // Private backing field for the property
    private bool show = false;
    // Property to get and set the enabled state
    public bool IsShow
    {
        get { return show; }
        set
        {
            show = value;

            if (show)
            {

            }
            else
            {
                GetComponent<SpriteGlowEffect>().enabled = !show;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = UIManagerGameBoard.Instance.gameUI.backCard;
                GetComponent<SpriteGlowEffect>().enabled = show;
                GetComponent<SpriteRenderer>().sortingOrder = 2;
            }
        }
    }
    private bool mine = false;

    // Property to get and set the enabled state
    public bool IsMine
    {
        get { return mine; }
        set
        {
            mine = value;

            if (mine)
            {
                GetComponent<CardObject>().enabled = mine;
                GetComponent<BoxCollider2D>().enabled = mine;
            }
            else
            {
                GetComponent<CardObject>().enabled = mine;
                GetComponent<BoxCollider2D>().enabled = mine;
                // Disable functionality
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        IsActive = true;
        Locked = false;
        myLocalScale = this.gameObject.GetComponent<Transform>().localScale;
        eventTrigger = gameObject.GetComponent<EventTrigger>();

        EventTrigger.Entry clickTrigger = new EventTrigger.Entry();
        EventTrigger.Entry drag = new EventTrigger.Entry();
        drag.eventID = EventTriggerType.Drag;
        drag.callback.AddListener((eventData) => { OnMouseDrag(); });
        eventTrigger.triggers.Add(clickTrigger);

        EventTrigger.Entry dropTrigger3 = new EventTrigger.Entry();
        dropTrigger3.eventID = EventTriggerType.EndDrag;
        dropTrigger3.callback.AddListener((eventData) => { OnMouseDrop(); });
        eventTrigger.triggers.Add(dropTrigger3);

        EventTrigger.Entry dropTrigger4 = new EventTrigger.Entry();
        dropTrigger4.eventID = EventTriggerType.PointerEnter;
        dropTrigger4.callback.AddListener((eventData) => { OnPointerEnter(); });
        eventTrigger.triggers.Add(dropTrigger4);

        EventTrigger.Entry dropTrigger5 = new EventTrigger.Entry();
        dropTrigger5.eventID = EventTriggerType.PointerExit;
        dropTrigger5.callback.AddListener((eventData) => { OnPointerExit(); });
        eventTrigger.triggers.Add(dropTrigger5);

        EventTrigger.Entry dropTrigger6 = new EventTrigger.Entry();
        dropTrigger6.eventID = EventTriggerType.PointerUp;
        dropTrigger6.callback.AddListener((eventData) => { OnMouseDrop(); });
        eventTrigger.triggers.Add(dropTrigger6);
    }
    void OnPointerEnter()
    {
        //Debug.Log("OnPointerEnter!");
        this.gameObject.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.2f);
    }
    void OnPointerExit()
    {
        //Debug.Log("OnPointerEnter!");
        this.gameObject.transform.DOScale(new Vector3(1f, 1f, 1f), 0.2f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void display(bool val)
    {
        IsShow = false;
    }
    
    public void OnMouseDrag()
    {
        if (!Locked)
        {
            Debug.Log("OnMouseDrag!");
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
        }
    }
    private void OnMouseDrop()
    {
        Debug.Log("OnMouseDrop!");
        if (dropLocation != null)
        {
            dropLocation.OnDrop(this.gameObject);
            Locked = true;
        }
        else
        {
            Debug.Log("dropLocation null");
            this.gameObject.transform.DOLocalMove(new Vector3(0f, 0f, 0f), 0.4f);//= new Vector3(0f, 0f, 0f);
            this.gameObject.transform.DOScale(new Vector3(1,1,1), 0.4f);//= new Vector3(0f, 0f, 0f);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collision " + other.name);
        other.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
        other.gameObject.GetComponent<SpriteRenderer>().sprite = this.gameObject.GetComponent<SpriteRenderer>().sprite;
        if (dropLocation != null)
        {
            placeHolder.GetComponent<SpriteGlowEffect>().enabled = false;
        }
        dropLocation = other.gameObject.GetComponent<DropZone>();
        placeHolder = other.gameObject;
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.clear;
        other.gameObject.GetComponent<SpriteGlowEffect>().enabled = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<SpriteRenderer>().sprite = UIManagerGameBoard.Instance.gameUI.cardBGBoard;
        this.gameObject.GetComponent<Transform>().localScale = myLocalScale - new Vector3(0.1f, 0.1f, 0.1f);
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        collision.GetComponent<SpriteRenderer>().color = Color.white;
        dropLocation = null;
        collision.gameObject.GetComponent<SpriteGlowEffect>().enabled = false;
    }
}
