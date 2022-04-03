using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public interface ISpriteAnimatorController
    {
        public void StartAnimations(SpriteRenderer spriteRenderer, AnimState track, bool loop);
        public void StopAnimations(SpriteRenderer sprite);
    }
}

