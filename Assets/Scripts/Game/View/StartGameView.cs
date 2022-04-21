using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC.game
{
    public class StartGameView : MonoBehaviour
    {
        public Action StartGame;
        public void Awake()
        {
            StartGame?.Invoke();
        }

    }
}
