using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class MoveController : IMoveController
    {
        private bool isFacingRight = true;
        public void Move(IPlayerBehavior playerBehavior, ISpriteAnimatorController spriteAnimatorController, LevelObjectView levelObjectView)
        {
            float move = Input.GetAxis("Horizontal");
            playerBehavior.Rigidbody.velocity = new Vector2(move * GameSettings.PLAYER_SPEED, playerBehavior.Rigidbody.velocity.y);

            if (move > 0 && !isFacingRight)
            {
                Flip(playerBehavior);
                MoveAnim(spriteAnimatorController, levelObjectView);
            }
            else if (move < 0 && isFacingRight)
            {
                Flip(playerBehavior);
                MoveAnim(spriteAnimatorController, levelObjectView);

            }
            else if (move == 0)
            {
                spriteAnimatorController.StartAnimations(levelObjectView._spriteRenderer, AnimState.idle, true);
            }

        }
        private void MoveAnim(ISpriteAnimatorController spriteAnimatorController, LevelObjectView levelObjectView)
        {
            spriteAnimatorController.StopAnimations(levelObjectView._spriteRenderer);
            spriteAnimatorController.StartAnimations(levelObjectView._spriteRenderer, AnimState.Run, true);
        }
        private void Flip(IPlayerBehavior playerBehavior)
        {
            isFacingRight = !isFacingRight;

            Vector3 theScale = playerBehavior._Transform.localScale;

            theScale.x *= -1;

            playerBehavior._Transform.localScale = theScale;
        }
    }
}

