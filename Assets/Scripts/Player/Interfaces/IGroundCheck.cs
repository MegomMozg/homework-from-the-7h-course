using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGroundCheck
{
    public Transform Transform { get;}
    public bool OnGround { get; set; }
    public bool OnGravity { get; set; }
    public LayerMask Ground { get;}
    public LayerMask Gravity { get; }

}
