using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour, IPlayerBehavior
{
    [SerializeField]private Rigidbody2D _rigidbody;
    [SerializeField]private Transform _transform;
    public Rigidbody2D Rigidbody { get { return _rigidbody; } }
    public Transform _Transform { get { return _transform; } }
}
