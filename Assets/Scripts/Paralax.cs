using TMPro;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    [SerializeField] private Transform _targetCamera;
    [SerializeField] private float _distanceScale = 1;
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
        var cameraDistance = _targetCamera.position - _cameraStartPosition;
        transform.position = _startPosition + cameraDistance * _distanceScale;
        while (transform.position.x < -_xLimit)
        {
            transform.Translate(_width * 2, 0, 0);
        }
        while (transform.position.x > _xLimit)
        {
            transform.Translate(-_width * 2, 0, 0);
        }
    }
}
