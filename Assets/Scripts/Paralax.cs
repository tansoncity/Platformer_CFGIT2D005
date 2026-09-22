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

    private void LateUpdate() => UpdateDistance();

    private void UpdateDistance()
    {
        var cameraDistance = _targetCamera.position - _cameraStartPosition;
        var newPosition = _startPosition;
        newPosition.x += cameraDistance.x * _horizontalScale;
        newPosition.y += cameraDistance.y * _verticalScale;

        ApplyDistanceLoop(ref newPosition);
        transform.position = newPosition;
    }

    private void ApplyDistanceLoop(ref Vector3 newPosition)
    {
        var xOffset = newPosition.x - _targetCamera.position.x;
        while (xOffset < -_width / 2)
        {
            xOffset += _width;
        }
        while (xOffset > _width / 2)
        {
            xOffset -= _width;
        }
        newPosition.x = _targetCamera.position.x + xOffset;
    }
}
