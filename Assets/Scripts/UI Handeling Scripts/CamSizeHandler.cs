using UnityEngine;

[ExecuteAlways]
public class CamSizeHandler : MonoBehaviour
{
    [SerializeField] Camera maincamera;
    [SerializeField] float sensitivity;

    void Update()
    {
        float unitsPerPixel = sensitivity / Screen.width;

        float desiredHalfHeight = 0.5f * unitsPerPixel * Screen.height;

        maincamera.orthographicSize = desiredHalfHeight;
    }
}