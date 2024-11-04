using System;
using DG.Tweening;
using UnityEngine;

public class ObstacleRotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;

    private void Update()
    {
        DefaultRotate();
    }

    private void DefaultRotate()
    {
        var rotationVector3 = Vector3.up * (rotationSpeed * Time.deltaTime);

        transform.Rotate(rotationVector3);
    }
}
