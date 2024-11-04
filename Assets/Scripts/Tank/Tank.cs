using DG.Tweening;
using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] private BulletPool bulletPool;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private float shootForce;
    [SerializeField] private float reloadTime;
    [SerializeField] private float kickbackDistance;

    private float timeAfterShoot;

    private void Update()
    {
        timeAfterShoot += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            if (timeAfterShoot > reloadTime)
            {
                Shoot();
                timeAfterShoot = 0f;
            }
        }
    }

    private void Shoot()
    {
        var newBullet = bulletPool.GetBulletFromPool(bulletSpawnPoint.position,Quaternion.identity);
        newBullet.Rigidbody.AddForce(Vector3.forward * shootForce, ForceMode.Impulse);
        
        // ShootAnimation();
    }

    private void ShootAnimation()
    {
        var sequence = DOTween.Sequence();

        var kickback = transform.DOMoveZ(transform.position.z - kickbackDistance, reloadTime)
            .SetLoops(2, LoopType.Yoyo);
        
        var up = transform.DOMoveY(1f, 0.5f).SetLoops(2,LoopType.Yoyo);
        var rotation = transform.DORotate(new Vector3(0f,360f,0f), reloadTime, RotateMode.FastBeyond360);
        
        sequence.Append(kickback).PrependInterval(0.2f)
            .Append(up).PrependInterval(0.2f)
            .Append(rotation);
    }
}
