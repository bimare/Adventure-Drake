using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    public int healthValue; 
    [SerializeField] private AudioClip HealingItem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SoundManager.instance.PlaySound(HealingItem);
            collision.GetComponent<PlayerHealth>().Healing(healthValue);
            gameObject.SetActive(false);
        }
    }
}
