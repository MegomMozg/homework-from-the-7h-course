using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlatformerMVC.game
{
    public class End : IUpdate
    {
        #region Classes
        public event Action GameOver;
        public event Action Winner;
        private Death_Zone _death;
        private Win _win;
        private FinishBehavior _FinishBehavior;
        private PlayerController _PlayerController;
        private GameSettings _GameSettings;
        #endregion
        public End(PlayerController playerController)
        {
            #region searization
            _PlayerController = playerController;
            _death = GameObject.FindObjectOfType<Death_Zone>();
            _win = GameObject.FindObjectOfType<Win>();
            _GameSettings = Resources.Load<GameSettings>(ResourcesPathes.GAME_SETTINGS);
            #endregion
        }

        public void Update(float deltatime)
        {
            Game_Over();
            Winn();
        }

        private void Game_Over()
        {
            bool IsGameOver = _GameSettings.DeathZone;
            if (IsGameOver == true)
            {
                Collider2D collider = Physics2D.OverlapBox(_death._Transform.position, new Vector2(300, 10), 0f);
                if (collider.CompareTag("Player"))
                {
                    Restart();
                    GameOver?.Invoke();
                }
            }
            else return;
        }
        private void Winn()
        {
            bool IsWin = _GameSettings.Finish;
            if (IsWin == true)
            {
                Collider2D collider = Physics2D.OverlapBox(_win.transform.position, new Vector2(9.37f, 20), 0f);
                if (collider.CompareTag("Player"))
                {
                    #region Bool
                    _win.MeshRenderer.enabled = false;
                    _PlayerController.IsMove = false;
                    _PlayerController.Deth(true);

                    #endregion
                    #region Canvas
                    var prefab = Resources.Load<GameObject>(ResourcesPathes.FINISH_CANVAS);
                    var canvas = GameObject.Instantiate(prefab);
                    _FinishBehavior = canvas.GetComponent<FinishBehavior>();
                    _FinishBehavior.OnRestartButtonClick += Restart;
                    Winner?.Invoke();
                    #endregion
                }
            }
            else return;
        }
        private void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

