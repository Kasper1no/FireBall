using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private DestroyBlockEffect destroyBlockEffect;

    public event UnityAction<Block> OnBlockDestroyed;
    
    public void SetColor(Color color)
    {
        meshRenderer.material.color = color;
    }

    public void Destroy()
    {
        OnBlockDestroyed?.Invoke(this);
        
        var destroyEffect = Instantiate(destroyBlockEffect, transform.position, destroyBlockEffect.transform.rotation);
        destroyEffect.ParticleSystemRenderer.material.color = meshRenderer.material.color;
        
        gameObject.SetActive(false);
    }
}