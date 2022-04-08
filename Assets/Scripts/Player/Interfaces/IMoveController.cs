using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public interface IMoveController
    {
        void Move(IPlayerBehavior playerBehavior);
        void Jump(IPlayerBehavior playerBehavior, IGroundCheck groundCheck);
    }
}

