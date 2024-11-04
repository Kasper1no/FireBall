using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private Block blockTemplate;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Vector2Int towerMinMaxSize;
    [SerializeField] private Color[] colors;
    
    private List<Block> blocks = new List<Block>();
    private int towerSize;

    public List<Block> Build()
    {
        var currentSpawnPoint = spawnPoint.position;
        var currentRoation = spawnPoint.rotation;
        towerSize = Random.Range(towerMinMaxSize.x, towerMinMaxSize.y);
        
        for (int i = 0; i < towerSize; i++)
        {
            var newBlock = NewBlock(currentSpawnPoint);
            newBlock.SetColor(colors[Random.Range(0, colors.Length)]);
            newBlock.transform.rotation = currentRoation;
            blocks.Add(newBlock);
            
            currentSpawnPoint = newBlock.transform.position;
            currentRoation = Quaternion.Euler(0, currentRoation.eulerAngles.y + 5, 0);
        }
        return blocks;
    }

    private Block NewBlock(Vector3 spawnPosition)
    {
        return Instantiate(blockTemplate, SpawnPosition(spawnPosition), Quaternion.identity, spawnPoint);
    }

    private Vector3 SpawnPosition(Vector3 currentSpawnPosition)
    {
        return new Vector3(currentSpawnPosition.x,  currentSpawnPosition.y + blockTemplate.transform.localScale.y / 2f, currentSpawnPosition.z);
    }
}
