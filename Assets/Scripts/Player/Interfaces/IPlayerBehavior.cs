using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerBehavior
{
    public Rigidbody2D Rigidbody { get; }
    public Transform _Transform { get; }
    public SpriteRenderer spriteRenderer { get; set; }
    public Animator animator { get; set; }
    public Vector2 vector2 { get;}
}
