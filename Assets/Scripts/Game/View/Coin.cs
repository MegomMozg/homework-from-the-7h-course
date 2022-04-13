using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class Coin : MonoBehaviour
    {
        private ParticleSystem ParticleSystem;

        [System.Obsolete]
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Coin"))
            {
                collision.gameObject.GetComponent<ParticleSystem>().Play();
                Destroy(collision.gameObject.GetComponent<SpriteRenderer>());
                Destroy(collision.gameObject.GetComponent<Collider2D>());
                Destroy(collision.gameObject, collision.gameObject.GetComponent<ParticleSystem>().startLifetime + collision.gameObject.GetComponent<ParticleSystem>().duration);
            }
            
        }
    }
}
