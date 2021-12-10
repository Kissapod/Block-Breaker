using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
 public void LoadLevel(string name)
    {
        Debug.Log("Запрошена загрузка уровня: "+name);
        Application.LoadLevel(name);
    }

    public void QuitGame()
    {
        Debug.Log("Запрошен выход из игры");
        Application.Quit();
    }
    public void LoadNextLevel()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }

    public void BrickDestroyed()
    {
        if (Brick.breakebleCount <=0)
        {
            LoadNextLevel();
        }
    }
}
