using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [SerializeField] public List<GameObject> level;
    private void Awake()
    {

        instance = this;
    }

    public void LoadLevel(int levelIndex)
    {
        level[levelIndex].SetActive(true);
    }

    
}
