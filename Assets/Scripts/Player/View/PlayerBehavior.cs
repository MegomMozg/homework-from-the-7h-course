using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu(menuName: "Behavior/Player/Player")]
public class PlayerBehavior : MonoBehaviour, IPlayerBehavior
{
    [SerializeField]private Rigidbody2D _rigidbody;
    [SerializeField]private Transform _transform;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator _animator;
    public Rigidbody2D Rigidbody { get { return _rigidbody; } }
    public Transform _Transform { get { return _transform; } }
    public SpriteRenderer spriteRenderer { get { return _spriteRenderer; } set { } }
    public Animator animator { get { return _animator; } set { } }
    public Vector2 vector2 { get;}
}
