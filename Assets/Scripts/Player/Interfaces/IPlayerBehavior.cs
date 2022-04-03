using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerBehavior
{
    public Rigidbody2D Rigidbody { get; }
    public Transform _Transform { get; }
}
