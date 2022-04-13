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
        public void Move(IPlayerBehavior playerBehavior, PlayerSettings playerSettings)
        {
            Vector = playerBehavior.vector2;
            Vector.x = Input.GetAxis("Horizontal");
            playerBehavior.animator.SetFloat("Move", Mathf.Abs(Vector.x));
            playerBehavior.Rigidbody.velocity = new Vector2(Vector.x * playerSettings.Speed, playerBehavior.Rigidbody.velocity.y);

            Flip(playerBehavior, Vector.x);
        }
        public void Jump(IPlayerBehavior playerBehavior, IGroundCheck groundCheck, PlayerSettings playerSettings)
        {
            
            if (Input.GetKeyDown(KeyCode.Space) && groundCheck.OnGround)
            {
                playerBehavior.Rigidbody.AddForce(Vector2.up * playerSettings.JumpForce);
            }
            playerBehavior.animator.StopPlayback();
            groundCheck.OnGround = Physics2D.OverlapCircle(groundCheck.Transform.position, 0.7f, groundCheck.Ground);
            playerBehavior.animator.SetBool("Jump", groundCheck.OnGround);
            groundCheck.OnGravity = Physics2D.OverlapCircle(groundCheck.Transform.position, 0.7f, groundCheck.Gravity);
            if (groundCheck.OnGravity == true)
            {
                playerBehavior.Rigidbody.gravityScale = 7;
                playerSettings.JumpForce = 3200;
            }
            else
            {
                playerSettings.JumpForce = 1400;
                playerBehavior.Rigidbody.gravityScale = 1;
            }

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

