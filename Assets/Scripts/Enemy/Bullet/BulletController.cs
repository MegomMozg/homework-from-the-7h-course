using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class BulletController : IUpdate, IBulletController
    {
        private BulletBehavior _BulletBehavior;
        public BulletController()
        {
            _BulletBehavior = Resources.Load<BulletBehavior>("Bullet");
        }
        public void Update(float deltatime)
        {
            Vector3 direction = _BulletBehavior.transform.forward * 5f * Time.fixedDeltaTime;
            _BulletBehavior.transform.position += direction;
        }
        
        private void Inintilization(float lifeTime, Transform target)
        {
            Object.Destroy(_BulletBehavior.gameObject, lifeTime);
        }
        public void Fire(Transform Gun)
        {
            GameObject bulletObject = Object.Instantiate(Resources.Load<BulletBehavior>("Bullet").gameObject, Gun.position, Gun.rotation);
            _BulletBehavior = bulletObject.transform.GetComponent<BulletBehavior>();
            Inintilization(7f, null);
        }
    }
}
