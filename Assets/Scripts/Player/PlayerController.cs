using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public sealed class PlayerController : IUpdate
    {
        #region Classes
        private IPlayerBehavior _PlayerBehavior;
        private IMoveController _MoveController;
        private IGroundCheck _GroundCheck;
        private PlayerSettings _PlayerSettings;
        public bool IsMove = true;
        #endregion
        public PlayerController()
        {
            #region searization
            _MoveController = new MoveController();
            _PlayerBehavior = GameObject.FindObjectOfType<PlayerBehavior>();
            _GroundCheck = GameObject.FindObjectOfType<GroundCheck>();
            _PlayerBehavior.animator = Animator.FindObjectOfType<Animator>();
            _PlayerSettings = Resources.Load<PlayerSettings>(ResourcesPathes.PLAYER_SETTINGS);
            #endregion
        }
        public void Update(float deltatime)
        {
            #region Move
            Move();
            #endregion
        }
        public void Move()
        {
            if (IsMove == true)
            {
                _MoveController.Move(_PlayerBehavior, _PlayerSettings);
                _MoveController.Jump(_PlayerBehavior, _GroundCheck, _PlayerSettings);
            }
            else if (IsMove == false)
            {
                Object.Destroy(_PlayerBehavior.spriteRenderer);
                Object.Destroy(_PlayerBehavior.Rigidbody);
            }
        }
    }
}

