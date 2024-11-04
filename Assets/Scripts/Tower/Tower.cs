using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TowerBuilder))]
public class Tower : MonoBehaviour
{
    [SerializeField] private TowerBuilder towerBuilder;
    
    private List<Block> _blocks = new List<Block>();
    
    public event UnityAction OnTowerDestroyed;
    
    public event UnityAction<int> OnTowerSizeUpdated;

    private void Start()
    {
        _blocks = towerBuilder.Build();

        foreach (var block in _blocks)
        {
            block.OnBlockDestroyed += OnBlockDestroyed;
        }
        OnTowerSizeUpdated?.Invoke(_blocks.Count);
    }

    private void OnBlockDestroyed(Block destroyedBlock)
    {
        _blocks.Remove(destroyedBlock);
        
        foreach (var block in _blocks)
        {
            block.transform.position = LevelDownVector(block);
        }
        
        OnTowerSizeUpdated?.Invoke(_blocks.Count);
        Destroy();
    }

    private static Vector3 LevelDownVector(Block block)
    {
        return new Vector3(block.transform.position.x,  block.transform.position.y - block.transform.localScale.y / 2f, block.transform.position.z);
    }

    private void Destroy()
    {
        if (_blocks.Count == 0)
        {
            OnTowerDestroyed?.Invoke();
        }
    }
}
