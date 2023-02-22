using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject finishedScreen;
    public int currentLevel = 0;

    public static UIManager instance;

    private void Awake()
    {
        finishedScreen.SetActive(false);
        instance = this;
    }

    public void OnFinishedLevel()
    {
        //LevelManager.instance.level[currentLevel].SetActive(false);
        finishedScreen.SetActive(true);
        currentLevel++;
    }

    public void OnNextLevelButton()
    {
        if(currentLevel >= 5)
        {
            currentLevel = 0;
        }

        LevelManager.instance.LoadLevel(currentLevel);
    }

    public void OnRestartLevelButton()
    {
        currentLevel--;
        LevelManager.instance.LoadLevel(currentLevel);
    }
}
