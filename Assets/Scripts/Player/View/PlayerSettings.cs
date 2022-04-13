using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "Player/PlayerSettings", order = 1)]
    public class PlayerSettings : ScriptableObject
    {
        public float JumpForce = 1400;
        public float Speed = 10;
    }
}

