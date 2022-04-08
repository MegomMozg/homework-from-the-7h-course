using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public enum AnimState
    {
        idle = 0,
        Run = 1,
        Jump = 2
    }
    [CreateAssetMenu(fileName = "SpriteAnimatorCFG", menuName = "Configs/ Animations", order = 1)]
    public class SpriteAnimatorConfig : ScriptableObject
    {
        [Serializable]
        public sealed class SpriteSquence
        {
            public AnimState Track;
            public List<Sprite> Sprites = new List<Sprite>();
        }

        public List<SpriteSquence> Squences = new List<SpriteSquence>();
    }

}
