using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class MoveController : IMoveController
    {
        #region Classes
        private Vector2 Vector;
        private bool isFacingRight = true;
        #endregion
        public void Move(IPlayerBehavior playerBehavior)
        {
            Vector = playerBehavior.vector2;
            Vector.x = Input.GetAxis("Horizontal");
            playerBehavior.animator.SetFloat("Move", Mathf.Abs(Vector.x));
            playerBehavior.Rigidbody.velocity = new Vector2(Vector.x * GameSettings.PLAYER_SPEED, playerBehavior.Rigidbody.velocity.y);

            Flip(playerBehavior, Vector.x);
        }
        public void Jump(IPlayerBehavior playerBehavior, IGroundCheck groundCheck)
        {
            
            if (Input.GetKeyDown(KeyCode.Space) && groundCheck.OnGround)
            {
                playerBehavior.Rigidbody.AddForce(Vector2.up * GameSettings.PLAYER_JUMPFORCE);
            }
            groundCheck.OnGround = Physics2D.OverlapCircle(groundCheck.Transform.position, 0.7f, groundCheck.Ground);
            playerBehavior.animator.SetBool("Jump", groundCheck.OnGround);
        }
        
        private void Flip(IPlayerBehavior playerBehavior, float move)
        {
            if ((move > 0 && !isFacingRight) || (move < 0 && isFacingRight))
            {
                Vector3 theScale = playerBehavior._Transform.localScale;

                theScale.x *= -1;

                playerBehavior._Transform.localScale = theScale;
                isFacingRight = !isFacingRight;
            }
            
        }
    }
}

