using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BridgeRotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;

    private void Start()
    {
        var rotationVector = new Vector3(0f, 360f, 0f);

        transform.DORotate(rotationVector, rotationSpeed, RotateMode.LocalAxisAdd).SetLoops(-1, LoopType.Yoyo);
    }
}
