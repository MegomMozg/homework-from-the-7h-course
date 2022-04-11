using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class Background : IUpdate
    {
        private Transform _transform;
        public bool IsBackground = true;
        public Background()
        {
            _transform = BackGroundBehavior.FindObjectOfType<BackGroundBehavior>()._transform;
        }
        public void Update(float deltatime)
        {
            if (IsBackground == true)
            {
                BackGroundBehavior.FindObjectOfType<BackGroundBehavior>().transform.position = Vector2.MoveTowards(BackGroundBehavior.FindObjectOfType<BackGroundBehavior>().transform.position, _transform.position, 10f);
            }
        }
        public void ground()
        {
            IsBackground = false;
        }
    }
}

