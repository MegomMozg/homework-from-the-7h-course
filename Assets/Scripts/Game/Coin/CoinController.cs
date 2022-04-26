using PlatformerMVC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC.game.Coin
{
    public class CoinController : IUpdate
    {
        private CoinList _coins;
        private CoinCanvas _Canvas;
        private GameSettings _Settings;
        public int Count;
        public CoinController()
        {
            _Settings = Resources.Load<GameSettings>(ResourcesPathes.GAME_SETTINGS);
            _Canvas = Object.FindObjectOfType<CoinCanvas>();
            _coins = Object.FindObjectOfType<CoinList>();
            Coin[] arrayCoins = GameObject.FindObjectsOfType<Coin>();
            _coins.coins.AddRange(arrayCoins);
            if (_Settings.Coin == true)
            {
                foreach (Coin coin in _coins.coins)
                {
                    coin.OnCollisionEnter += UpdateCoin;

                }

            }
            else return;
        }

        public void Update(float deltaTime)
        {
            QuestCoins();
        }
        private void UpdateCoin(Coin coin)
        {
            Count++;
            coin.gameObject.GetComponent<ParticleSystem>().Play();
            Object.Destroy(coin.gameObject.GetComponent<SpriteRenderer>());
            Object.Destroy(coin.gameObject.GetComponent<Collider2D>());
            Object.Destroy(coin.gameObject, 0.1f);
            _coins.coins.Remove(coin);
            
        }

        

        public void QuestCoins()
        {
            int CountMax = 3;
            _Canvas.Score.text ="Score: " + Count.ToString() + "/" + CountMax.ToString();
        }
        
    }
}

