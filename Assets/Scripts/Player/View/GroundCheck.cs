using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour, IGroundCheck
{
    [SerializeField] private LayerMask _Ground;
    [SerializeField] private Transform _transform;
    public Transform Transform { get { return _transform; } }
    public bool OnGround { get; set; }
    public LayerMask Ground { get { return _Ground; } }
}
