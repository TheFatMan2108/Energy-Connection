using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int level = 1;
    private string KEY_LEVEL = "THISLEVEL";
    private void Awake()
    {
        if (Instance == null)Instance = this;
        else Destroy(gameObject);
    }
    public void LevelNext()
    {
        level++;
    }
   public void Save()
    {
        PlayerPrefs.SetInt(KEY_LEVEL,level);
    }
    public void Load()
    {
        level = PlayerPrefs.GetInt(KEY_LEVEL,0);
    }
}
