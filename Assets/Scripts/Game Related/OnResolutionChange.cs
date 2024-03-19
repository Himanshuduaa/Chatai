using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[ExecuteAlways]
public class OnResolutionChange : MonoBehaviour
{
    [SerializeField] float screenRatio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        
        float ratio = screenHeight / screenWidth;
        //Debug.Log(ratio);
        if (ratio < screenRatio)
        {
            GetComponent<CamSizeHandler>().enabled = false;
        }
        else
        {
            GetComponent<CamSizeHandler>().enabled = true;
        }
    }
}
