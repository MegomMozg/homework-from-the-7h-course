using PlatformerMVC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController //: IUpdate
{
    //private List<Coin> coins;
    //public CoinController()
    //{
    //    Coin[] arrayCoins = GameObject.FindObjectsOfType<Coin>();
    //    coins.AddRange(arrayCoins);
    //}
    
    //public void Update(float deltaTime)
    //{
    //    foreach (Coin coin in coins)
    //    {
    //        UpdateCoin(coin, deltaTime);
    //    }
    //}

    //public void UpdateCoin(Coin coin, float deltaTime)
    //{

    //}

    public void OnTriggerEnter2D(Coin coin, Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            collision.gameObject.GetComponent<ParticleSystem>().Play();
            //Destroy(collision.gameObject.GetComponent<SpriteRenderer>());
            //Destroy(collision.gameObject.GetComponent<Collider2D>());
            //Destroy(collision.gameObject, 0.1f);
        }

    }
}
