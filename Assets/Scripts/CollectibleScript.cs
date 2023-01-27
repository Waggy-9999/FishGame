using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// If the player collides with a currency, this script destroys it and increases the number of collected.
/// </summary>
public class CollectibleScript : MonoBehaviour
{
    public AudioClip pickupSound;
    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.tag == "Player")
        {
            PlayerManager.instance.AddCurrency();

            AudioSource.PlayClipAtPoint(pickupSound, transform.position, 1);
            Destroy(gameObject);
        }
    }
}
