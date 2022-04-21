using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public interface IMoveController
    {
        void Move(IPlayerBehavior playerBehavior, PlayerSettings playerSettings);
        void Jump(IPlayerBehavior playerBehavior, IGroundCheck groundCheck, PlayerSettings playerSettings);
    }
}

