using UnityEngine;

public class DebuffCollectable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var shrink = collision.GetComponent<PlayerShrink>();
            if (shrink != null)
            {
                shrink.ShrinkPlayer();
            }
        }
    }
}
