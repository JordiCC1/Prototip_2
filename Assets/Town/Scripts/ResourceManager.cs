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

    public int attackBonus;
    public int healthBonus;
    

    // Start is called before the first frame update
    void Start()
    {
        totalFood = 100.0f;
        totalMaterial = 100.0f;
        totalPeople = 10.0f;
        currentFood = totalFood;
        currentMaterial = totalMaterial;
        currentPeople = totalPeople;


        attackBonus = 0;
        healthBonus = 0;


        PlayerPrefs.SetFloat("food", currentFood);
        PlayerPrefs.SetFloat("material", currentMaterial);
        PlayerPrefs.SetFloat("people", currentPeople);
        PlayerPrefs.SetFloat("attackBonus", attackBonus);
        PlayerPrefs.SetFloat("healthBonus", healthBonus);
    }

    private void Update()
    {
        currentFood = Mathf.Clamp(PlayerPrefs.GetFloat("food"), 0, totalFood);
        currentMaterial = Mathf.Clamp(PlayerPrefs.GetFloat("material"), 0, totalMaterial);
        currentPeople = Mathf.Clamp(PlayerPrefs.GetFloat("people"), 0, totalPeople);
        attackBonus = PlayerPrefs.GetInt("attackBonus");
        healthBonus = PlayerPrefs.GetInt("healthBonus");
    }

    public void ChangeFood(float amount)
    {
        float temp = currentFood + amount;
        currentFood = Mathf.Clamp(temp, 0, totalFood);
        PlayerPrefs.SetFloat("food", currentFood);
    }
    public void ChangeMaterial(float amount)
    {
        float temp = currentMaterial + amount;
        currentMaterial = Mathf.Clamp(temp, 0, totalMaterial);
        PlayerPrefs.SetFloat("material", currentMaterial);
    }
    public void ChangePeople(float amount)
    {
        float temp = currentPeople + amount;
        currentPeople = Mathf.Clamp(temp, 0, totalPeople);
        PlayerPrefs.SetFloat("people", currentPeople);
    }

    public void ChangeAttackBonus(int amount)
    {
        attackBonus += amount;
        PlayerPrefs.SetFloat("attackBonus", attackBonus);
    }

    public void ChangeHealthBonus(int amount)
    {
        healthBonus += amount;
        PlayerPrefs.SetFloat("healthBonus", healthBonus);
    }
}
