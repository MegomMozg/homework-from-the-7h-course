using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class SpriteAnimatorController : IUpdate, IDisposable, ISpriteAnimatorController
    {
        public sealed class Animation
        {
            public AnimState Track;
            public List<Sprite> sprites;
            public bool Loop;
            public float Speed = 10;
            public float Counter = 0;
            public bool Sleep;
            public void Update()
            {
                if (Sleep) return;
                Counter += Time.deltaTime * Speed;

                if (Loop)
                {
                    while (Counter > sprites.Count)
                    {
                        Counter -= sprites.Count;
                    }
                }
                else if (Counter > sprites.Count)
                {
                    Counter = sprites.Count;
                    Sleep = true;
                }
            }
        }

        private SpriteAnimatorConfig _config;
        private Dictionary<SpriteRenderer, Animation> _ActiveAnimations = new Dictionary<SpriteRenderer, Animation>();

        public SpriteAnimatorController(SpriteAnimatorConfig spriteAnimatorConfig)
        {
            _config = spriteAnimatorConfig;
        }

        public void StartAnimations(SpriteRenderer spriteRenderer, AnimState track, bool loop)
        {
            if (_ActiveAnimations.TryGetValue(spriteRenderer, out var animation))
            {
                animation.Loop = loop;
                animation.Speed = GameSettings.FPS_UPDATE;
                
                if (animation.Track != track)
                {
                    animation.Track = track;
                    animation.sprites = _config.Squences.Find(sequence => sequence.Track == track).Sprites;
                    animation.Counter = 0;
                }
            }
            else
            {
                _ActiveAnimations.Add(spriteRenderer, new Animation()
                {
                    Track = track,
                    sprites = _config.Squences.Find(sequence => sequence.Track == track).Sprites,
                    Loop = loop,
                    Speed = GameSettings.FPS_UPDATE
                });
            }
        }

        public void StopAnimations(SpriteRenderer sprite)
        {
            if (_ActiveAnimations.ContainsKey(sprite))
            {
                _ActiveAnimations.Remove(sprite);
            }
        }
        public void Update(float deltatime)
        {
            foreach (var animation in _ActiveAnimations)
            {
                animation.Value.Update();
                if (animation.Value.Counter < animation.Value.sprites.Count)
                {
                    animation.Key.sprite = animation.Value.sprites[(int)animation.Value.Counter];
                }
            }
        }

        public void Dispose()
        {
            _ActiveAnimations.Clear();
        }
    }
}

