using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class ZoomLevel
{
    public float Zoom;
    public float forceMult;
}

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private List<ZoomLevel> _zoomLevelList = new List<ZoomLevel>();
    private float _currentZoom;


    void Update()
    {
        _currentZoom = Mathf.Lerp(_currentZoom, _zoomLevelList[GameManager.Instance.CurrentLevel].Zoom, Time.deltaTime * 5);
        SetZoom(_currentZoom);
    }

    private void SetZoom(float _zoom)
    {
        _camera.orthographicSize = _zoom;
        _camera.transform.position = new Vector3(0, _zoom, -10) + _offset;
    }

    public float GetForceMult()
    {
        return _zoomLevelList[GameManager.Instance.CurrentLevel].forceMult;
    }
}

