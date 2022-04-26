using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu(menuName: "Behavior/Player/GroundCheck")]
public class GroundCheck : MonoBehaviour, IGroundCheck
{
    [SerializeField] private LayerMask _Ground;
    [SerializeField] private LayerMask _Gravity;
    [SerializeField] private Transform _transform;
    public Transform Transform { get { return _transform; } }
    public bool OnGround { get; set; }
    public bool OnGravity { get; set; }
    public LayerMask Ground { get { return _Ground; } }
    public LayerMask Gravity { get { return _Gravity; } }
}
