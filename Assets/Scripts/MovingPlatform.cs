using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var playerTransform = collision.gameObject.transform;
            playerTransform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        var player = collision.gameObject;
        if (player.activeInHierarchy && player.CompareTag("Player"))
        {
            var playerTransform = collision.gameObject.transform;
            playerTransform.SetParent(null);
        }
    }
}
