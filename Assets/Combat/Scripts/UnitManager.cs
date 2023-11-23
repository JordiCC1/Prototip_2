using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnitManager : MonoBehaviour
{


    public static UnitManager Instance { get; private set; }
    public Menu menu;

    private List<Unit> unitList;
    private List<Unit> friendlyUnitList;
    private List<Unit> enemyUnitList;


    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one UnitManager!" + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;

        unitList = new List<Unit>();
        friendlyUnitList = new List<Unit>();
        enemyUnitList = new List<Unit>();
    }
    private void Start()
    {
        Unit.OnAnyUnitSpawned += Unit_OnAnyUnitSpawned;
        Unit.OnAnyUnitDead += Unit_OnAnyUnitDead;
    }


    private void Unit_OnAnyUnitSpawned(object sender, EventArgs e)
    {
        Unit unit = sender as Unit;

        unitList.Add(unit);

        if(unit.IsEnemy())
        {            
            enemyUnitList.Add(unit);
        } else
        {
            friendlyUnitList.Add(unit);
        }

    }

    private void Unit_OnAnyUnitDead(object sender, EventArgs e)
    {
        Unit unit = sender as Unit;

        unitList.Remove(unit);

        if (unit.IsEnemy())
        {
            enemyUnitList.Remove(unit);
            if(enemyUnitList.Count == 0)
            {
                float temp = PlayerPrefs.GetFloat("material");
                temp += 25;
                PlayerPrefs.SetFloat("material", temp);

                temp = PlayerPrefs.GetFloat("people");
                temp += 10;
                PlayerPrefs.SetFloat("people", temp);

                temp = PlayerPrefs.GetFloat("food");
                temp += 20;
                PlayerPrefs.SetFloat("food", temp);


                menu.ChangeScene("TownScene");
            }
        }
        else
        {
            friendlyUnitList.Remove(unit);
            if (friendlyUnitList.Count == 0)
            {
                menu.ChangeScene("TownScene");
            }
        }
    }

    public List<Unit> GetUnitList()
    {
        return unitList;
    }

    public List<Unit> GetFriendlyUnitList()
    {
        return friendlyUnitList;
    }

    public List<Unit> GetEnemyUnitList()
    {
        return enemyUnitList;
    }
}
