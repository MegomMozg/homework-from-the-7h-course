using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class Background : IUpdate
    {
        private Transform _transform;
        private Vector3 velocity = Vector3.zero;
        public Background()
        {
            _transform = BackGroundBehavior.FindObjectOfType<BackGroundBehavior>()._transform;
        }
        public void Update(float deltatime)
        {
            BackGroundBehavior.FindObjectOfType<BackGroundBehavior>().transform.position = Vector2.MoveTowards(BackGroundBehavior.FindObjectOfType<BackGroundBehavior>().transform.position, _transform.position, 10f);
        }
    }
}

