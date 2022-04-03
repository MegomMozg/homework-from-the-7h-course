using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public sealed class PlayerController : IUpdate
    {
        private ISpriteAnimatorController _spriteAnimatorController;
        private IPlayerBehavior _PlayerBehavior;
        private IMoveController _MoveController;

        private LevelObjectView _LevelObjectView;
        public PlayerController(ISpriteAnimatorController spriteAnimatorController)
        {
            _spriteAnimatorController = spriteAnimatorController;
            _MoveController = new MoveController();
            _LevelObjectView = GameObject.FindObjectOfType<LevelObjectView>();
            _PlayerBehavior = GameObject.FindObjectOfType<PlayerBehavior>();
        }
        public void Update(float deltatime)
        {
            _MoveController.Move(_PlayerBehavior, _spriteAnimatorController, _LevelObjectView);
        }
    }
}

