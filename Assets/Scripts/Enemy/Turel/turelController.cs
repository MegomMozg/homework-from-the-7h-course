using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class turelController : IUpdate
    {
        private TurelBehavior _turelbehavior;
        private IBulletController _bulletController; 
        public turelController(IBulletController bulletController)
        {
            _bulletController = bulletController;
            _turelbehavior = TurelBehavior.FindObjectOfType<TurelBehavior>();
        }
        public void Update(float deltatime)
        {
            CheckPlayer();
        }

        private void CheckPlayer()
        {
            _turelbehavior._Collider = Physics2D.OverlapCircle(_turelbehavior._transform.position, 20f);
                if (_turelbehavior._Collider.CompareTag("Player"))
                {
                    var direction = _turelbehavior._transform.right - _turelbehavior._Collider.transform.position;
                    if (Physics2D.Raycast(_turelbehavior._transform.position, direction))
                        if (_turelbehavior._Collider.CompareTag("Player"))
                        {
                            _bulletController.Fire(_turelbehavior.Gun);
                        }
                }
        }

        
    }
}

