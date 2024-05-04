using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private float Health;
    [SerializeField] private AudioClip PickupSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag== "Player")
        {
            SoundManager.instance.Audio(PickupSound);
            collision.GetComponent<Health>().AddHealth(Health);
            gameObject.SetActive(false);
        }
    }
}
