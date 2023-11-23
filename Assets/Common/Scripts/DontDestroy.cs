using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{   
    public Menu menu;

    private void Update()
    {
        if(menu.changedScene) { gameObject.SetActive(true); }
        else { gameObject.SetActive(false); }
    }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
