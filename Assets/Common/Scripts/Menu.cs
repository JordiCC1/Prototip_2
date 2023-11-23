using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public bool changedScene = true;
    public void ChangeScene(string name)
    {
        if (changedScene) { changedScene = false; }
        else changedScene = true;
        SceneManager.LoadScene(name);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
