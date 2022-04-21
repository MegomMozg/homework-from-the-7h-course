using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC.game.Coin
{
    public class Coin : MonoBehaviour
    {
        //private ParticleSystem ParticleSystem;
        //public CoinController controller;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            //controller.OnTriggerEnter2D(this, collision);
            //if (collision.gameObject.CompareTag("Coin"))
            //{
            //    collision.gameObject.GetComponent<ParticleSystem>().Play();
            //    Destroy(collision.gameObject.GetComponent<SpriteRenderer>());
            //    Destroy(collision.gameObject.GetComponent<Collider2D>());
            //    Destroy(collision.gameObject, 0.1f);
            //}
            
        }
    }
}
