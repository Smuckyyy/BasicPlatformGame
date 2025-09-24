// using UnityEngine;

// public class DebuffCollectable : MonoBehaviour
// {
//     //string test;
//     private void OnTriggerEnter2D(Collider2D collision)
//     {
//         if (collision.gameObject.CompareTag("Player"))
//         {
//             Transform debuffHat = collision.transform.Find("DebuffHat");
//             Instantiate(debuffHat, debuffHat.position, Quaternion.identity, debuffHat);
//             //Destroy(this.gameObject);
//         }
//     }
// }

using UnityEngine;

public class DebuffCollectable : MonoBehaviour
{
    public GameObject hatPrefab; // assign in inspector

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // find the empty slot on the player’s head
            Transform hatSlot = collision.transform.Find("DebuffHat");

            if (hatSlot != null && hatPrefab != null)
            {
                // spawn a hat at the hatSlot, parented to it
                Instantiate(hatPrefab, hatSlot.position, Quaternion.identity, hatSlot);
            }

            Destroy(gameObject); // remove the world collectable
        }
    }
}
