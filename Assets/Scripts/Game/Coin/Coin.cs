using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC.game.Coin
{
    [AddComponentMenu(menuName: "Behavior/Game/Coin/Coin")]
    public class Coin : MonoBehaviour
    {
        public Action<Coin> OnCollisionEnter;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                OnCollisionEnter?.Invoke(this);
            }
        }
    }
}
