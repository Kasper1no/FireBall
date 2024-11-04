using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerSize : MonoBehaviour
{
    [SerializeField] private Tower tower;
    [SerializeField] private TMP_Text towerSizeText;

    private void OnEnable()
    {
        tower.OnTowerSizeUpdated += OnTowerSizeUpdate;
    }

    private void OnDisable()
    {
        tower.OnTowerSizeUpdated -= OnTowerSizeUpdate;
    }

    private void OnTowerSizeUpdate(int size)
    {
        towerSizeText.text = size.ToString();
    }
}
