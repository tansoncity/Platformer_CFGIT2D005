using System;
using TMPro;
using UnityEngine;
using UnityEngine.Splines;

public class Paralax : MonoBehaviour
{
    [SerializeField] private Transform _targetCamera;

    [SerializeField] private float _horizontalScale = 1;
    [SerializeField] private float _verticalScale = 1;

    [SerializeField] private bool _horizontalLooped = false;
    [SerializeField] private float _width;
    [SerializeField] private float _xLimit;

    private Vector3 _cameraStartPosition;
    private Vector3 _startPosition;

    private void Start()
    {
        _cameraStartPosition = _targetCamera.position;
        _startPosition = transform.position;
    }

    private void LateUpdate()
    {
        UpdateDistance();
        //UpdateHeight();
    }

    private void UpdateDistance()
    {
        var cameraDistance = _targetCamera.position - _cameraStartPosition;
        var newPosition = _startPosition + cameraDistance * _horizontalScale;

        if (_horizontalLooped)
        {
            ApplyDistanceLoop(ref newPosition);
        }
        transform.position = newPosition;
    }

    private void ApplyDistanceLoop(ref Vector3 newPosition)
    {
        var xOffset = newPosition.x - _targetCamera.position.x;
        while (xOffset < -_xLimit)
        {
            xOffset += _width * 2;
        }
        while (xOffset > _xLimit)
        {
            xOffset -= _width * 2;
        }
        newPosition.x = _targetCamera.position.x + xOffset;
    }

    //private void UpdateHeight()
    //{
    //    var cameraHeight = _targetCamera.position - _cameraStartPosition;
    //    transform.position = _startPosition + cameraHeight * _heightScale;
    //}
}
