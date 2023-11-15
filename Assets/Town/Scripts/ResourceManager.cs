using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public float totalFood;
    public float currentFood;

    public float totalMaterial;
    public float currentMaterial;

    public float totalPeople;
    public float currentPeople;
    

    // Start is called before the first frame update
    void Start()
    {
        totalFood = 100.0f;
        totalMaterial = 100.0f;
        totalPeople = 10.0f;
        currentFood = totalFood;
        currentMaterial = totalMaterial;
        currentPeople = totalPeople;
    }

    public void ChangeFood(float amount)
    {
        float temp = currentFood + amount;
        currentFood = Mathf.Clamp(temp, 0, totalFood);
    }
    public void ChangeMaxFood(float amount)
    {
        totalFood += amount;
    }
    public void ChangeMaterial(float amount)
    {
        float temp = currentMaterial + amount;
        currentMaterial = Mathf.Clamp(temp, 0, totalMaterial);

    }
    public void ChangeMaxMaterial(float amount)
    {
        totalMaterial += amount;
    }
    public void ChangePeople(float amount)
    {
        float temp = currentPeople + amount;
        currentPeople = Mathf.Clamp(temp, 0, totalPeople);
    }
    public void ChangeMaxPeople(float amount)
    {
        totalPeople += amount;
    }
}
