using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlatformerMVC
{
    public class End : IUpdate
    {
        public event Action GameOver;
        public event Action Winner;
        private Death_Zone _death;
        private Win _win;
        public End()
        {
            _death = GameObject.FindObjectOfType<Death_Zone>();
            _win = GameObject.FindObjectOfType<Win>();
        }

        public void Update(float deltatime)
        {
            Game_Over();
            Winn();
        }

        private void Game_Over()
        {
            _death._collider = Physics2D.OverlapBox(_death.transform.position, _death.transform.forward, 10f);
            if (_death._collider.CompareTag("Player"))
            {
                GameOver?.Invoke();
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        private void Winn()
        {
            _win._collider = Physics2D.OverlapBox(_win.transform.position, _win.transform.forward, 10f);
            if (_win._collider.CompareTag("Player"))
            {
                Winner?.Invoke();
            }
        }
    }
}

