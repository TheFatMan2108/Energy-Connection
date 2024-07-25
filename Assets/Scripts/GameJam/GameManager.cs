using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private int LevelUnlock = 1;
    private int onMusic = 0;
    private int onSFX = 0;
    private string KEY_LEVEL = "THISLEVEL";
    private string KEY_MUSIC = "THISMUSIC";
    private string KEY_SFX = "THISSFX";
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        Load();
    }
    public void LevelNext(string name)
    {
        string[] data = name.Split('-');
        int thisLevel = int.Parse(data[1])+1;
        if (thisLevel > LevelUnlock)
        {
            if(thisLevel>=5)return;
            LevelUnlock = thisLevel;
        };
    }
    public void SetMusic(int m)
    {
        onMusic = m;
        AudioManager.instance.SetMuteBGM(0,onMusic!=0);
        Save();
    }
    public int GetMusic()=>onMusic;
    public void SetSFX(int s)
    {
        onSFX = s;
        AudioManager.instance.SetMuteMusicAll(onSFX!=0);
        Save();
    }
    public int GetSFX()=>onSFX;
    public void Save()
    {
        PlayerPrefs.SetInt(KEY_LEVEL, LevelUnlock);
        PlayerPrefs.SetInt(KEY_MUSIC, onMusic);
        PlayerPrefs.SetInt(KEY_SFX, onSFX);
        PlayerPrefs.Save();
    }
    public void Load()
    {
        LevelUnlock = PlayerPrefs.GetInt(KEY_LEVEL, 1);
        if (LevelUnlock >= 5) LevelUnlock = 5;
        onMusic = PlayerPrefs.GetInt(KEY_MUSIC, 0);
        onSFX = PlayerPrefs.GetInt(KEY_SFX, 0);
    }
    private void OnDestroy()
    {
        Save();
    }
    public int GetLevelUnlock()=>LevelUnlock;
}
