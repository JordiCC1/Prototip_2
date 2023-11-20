using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScripting : MonoBehaviour
{
    [SerializeField] private List<GameObject> hider1List;
    [SerializeField] private List<GameObject> hider2List;
    [SerializeField] private List<GameObject> hider3List;
    [SerializeField] private List<GameObject> enemy1List;
    [SerializeField] private List<GameObject> enemy2List;

    private bool hasShownFirstHider = false;

    private void Start()
    {
        LevelGrid.Instance.OnAnyUnitMovedGridPosition += LevelGrid_OnAnyUnitMovedGridPosition;
        
        
            SetActiveGameObjectList(hider2List, true);        
            SetActiveGameObjectList(hider3List, true);
            //SetActiveGameObjectList(enemy2List, true);
        
    }

    private void LevelGrid_OnAnyUnitMovedGridPosition(object sender, LevelGrid.OnAnyUnitMovedGridPositionEventArgs e)
    {
        if (e.toGridPosition.z == 5 && !hasShownFirstHider)
        {
            hasShownFirstHider = true;
            SetActiveGameObjectList(hider1List, false);
            SetActiveGameObjectList(enemy1List, true);
        }

        if (e.toGridPosition.z == 13)
        {
            hasShownFirstHider = true;
            SetActiveGameObjectList(hider2List, false);
            SetActiveGameObjectList(enemy2List, true);
        }
    }

    private void SetActiveGameObjectList(List<GameObject> gameObjectList, bool isActive)
    {
        foreach (GameObject gameObject in gameObjectList)
        {
            gameObject.SetActive(isActive);
        }
    }

}

