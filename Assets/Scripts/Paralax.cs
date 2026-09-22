using UnityEngine;

public class Paralax : MonoBehaviour
{
    [SerializeField] private Transform _targetCamera;
    [SerializeField] private float _horizontalScale = 1;
    [SerializeField] private float _verticalScale = 1;

    private Vector3 _cameraStartPosition;
    private Vector3 _startPosition;
    private float _width;

    private void Start()
    {
        _cameraStartPosition = _targetCamera.position;
        _startPosition = transform.position;
        _width = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void LateUpdate()
    {
        UpdateDistance();
        ApplyDistanceLoop();
    }

    private void UpdateDistance()
    {
        var cameraDistance = _targetCamera.position - _cameraStartPosition;
        transform.position = _startPosition + 
            new Vector3(cameraDistance.x * _horizontalScale, cameraDistance.y * _verticalScale, 0);
    }

    private void ApplyDistanceLoop()
    {
        var xOffset = transform.position.x - _targetCamera.position.x;
        if (xOffset < -_width / 2)
        {
            _startPosition.x += _width;
        }
        else if (xOffset > _width / 2)
        {
            _startPosition.x -= _width;
        }
    }
}
