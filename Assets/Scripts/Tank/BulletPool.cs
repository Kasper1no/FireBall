using UnityEngine;
using System.Collections.Generic;

public class BulletPool : MonoBehaviour
{
        [SerializeField] private Bullet bulletTemplate;
        [SerializeField] private int poolSize;
        [SerializeField] private int maxBulletInScene;
        
        private List<Bullet> _bulletPool = new List<Bullet>();
        private Bullet _bulletToGet;

        private void Start()
        {
            for (int i = 0; i < poolSize; i++)
            {
                var bullet = Instantiate(bulletTemplate, transform.position, Quaternion.identity);
                bullet.gameObject.SetActive(false);
                _bulletPool.Add(bullet);
            }
        }

        public Bullet GetBulletFromPool(Vector3 position, Quaternion rotation)
        {
            if (_bulletPool.Count > 0 && PoolActiveSelfCheck())
            {
                _bulletToGet = _bulletPool[Random.Range(0, _bulletPool.Count)];
                ResetBulletProperties(position, rotation);
            }
            else
            {
                _bulletToGet = Instantiate(bulletTemplate, transform.position, Quaternion.identity);
                _bulletPool.Add(_bulletToGet);
            }
            return _bulletToGet;
            
        }

        private bool PoolActiveSelfCheck()
        {
            var activeBullets = _bulletPool.FindAll(bullet => bullet.gameObject.activeSelf);

            if (activeBullets.Count == 0 && activeBullets.Count > maxBulletInScene) return false;
            return true;
        }

        private void ResetBulletProperties(Vector3 position, Quaternion rotation)
        {
            _bulletToGet.transform.position = position;
            _bulletToGet.transform.rotation = rotation;
            _bulletToGet.Rigidbody.velocity = Vector3.zero;
            _bulletToGet.gameObject.SetActive(true);
        }
}
