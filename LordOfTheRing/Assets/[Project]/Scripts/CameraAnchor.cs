using UnityEngine;

public class CameraAnchor : MonoBehaviour
{
    private Vector2 resolutionPos;
    private Camera mainCamera;
    private Vector2 _startPos;

    private void Start()
    {
        mainCamera = Camera.main;
        resolutionPos = mainCamera.WorldToScreenPoint(transform.position);
        _startPos = transform.position;
    }

    private void Update()
    {
        Vector3 newPos = mainCamera.ScreenToWorldPoint(resolutionPos);
        newPos.z = 0;
        newPos.y = _startPos.y;
        transform.position = newPos;
    }
}
