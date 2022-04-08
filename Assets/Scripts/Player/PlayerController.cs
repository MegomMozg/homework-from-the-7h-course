using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public sealed class PlayerController : IUpdate
    {
        private IPlayerBehavior _PlayerBehavior;
        private IMoveController _MoveController;
        private IGroundCheck _GroundCheck;

        public PlayerController()
        {
            _MoveController = new MoveController();
            _PlayerBehavior = GameObject.FindObjectOfType<PlayerBehavior>();
            _GroundCheck = GameObject.FindObjectOfType<GroundCheck>();
            _PlayerBehavior.animator = Animator.FindObjectOfType<Animator>();
        }
        public void Update(float deltatime)
        {
            _MoveController.Move(_PlayerBehavior);
            _MoveController.Jump(_PlayerBehavior, _GroundCheck);
        }
    }
}

