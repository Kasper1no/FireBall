using DG.Tweening;
using UnityEngine;

public class DOTWeenRotator : MonoBehaviour
{
    [SerializeField] private float rotationTime;
    private void Start()
    {
        DoTweenRotate();   
    }
    
    private void DoTweenRotate()
    {
        
        transform.DORotate(new Vector3(0, 360, 0), rotationTime, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Incremental);
    }
}
