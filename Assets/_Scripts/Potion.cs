using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public bool taken = false;
    public GameObject explosion;

    void OnTriggerEnter2D (Collider2D other)
    {
       if ((other.tag == "Player") && (!taken) && (other.gameObject.GetComponent<CharacterController2D>().playerCanMove))
       {
           // mark as taken so doesn't get taken multiple times
			taken=true;

			// if explosion prefab is provide, then instantiate it
			if (explosion)
			{
				Instantiate(explosion,transform.position,transform.rotation);
			}

			// do the player collect potion thing
			other.gameObject.GetComponent<CharacterController2D>().CollectPotion();

			// destroy the potion
			Destroy(this.gameObject);
       }
   }
}
