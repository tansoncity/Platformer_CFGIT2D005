using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _hitMask;
    [SerializeField] private Vector2 _size;

    public bool IsOnGround { get; private set; }

    private void Update()
        => IsOnGround = Physics2D.OverlapBox(transform.position,
            _size, angle: 0, _hitMask);

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, _size);

        if (IsOnGround)
        {
            Gizmos.DrawSphere(transform.position, 0.2f);
        }
    }
}
