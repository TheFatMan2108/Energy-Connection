using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int level = 1;
    private int onMusic = 0;
    private int onSFX = 0;
    private string KEY_LEVEL = "THISLEVEL";
    private string KEY_MUSIC = "THISMUSIC";
    private string KEY_SFX = "THISSFX";
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    public void LevelNext() => level++;
    public void SetMusic(int m)
    {
        onMusic = m;
        AudioManager.instance.SetMuteBGM(0,onMusic!=0?true:false);
    }
    public int GetMusic()=>onMusic;
    public void SetSFX(int s)
    {
        onSFX = s;
    }
    public int GetSFX()=>onSFX;
    public void Save()
    {
        PlayerPrefs.SetInt(KEY_LEVEL, level);
        PlayerPrefs.SetInt(KEY_MUSIC, onMusic);
        PlayerPrefs.SetInt(KEY_SFX, onSFX);
        PlayerPrefs.Save();
    }
    public void Load()
    {
        level = PlayerPrefs.GetInt(KEY_LEVEL, 0);
        onMusic = PlayerPrefs.GetInt(KEY_MUSIC, 0);
        onSFX = PlayerPrefs.GetInt(KEY_SFX, 0);
    }
}
