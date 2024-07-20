using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    public Sprite on, off;
    private List<GameObject> list = new List<GameObject>();
    private bool isMusic, isSFX;

    private void Awake()
    {
        list.Clear();
        list.Add(transform.GetChild(1).GetChild(0).gameObject);
        list.Add(transform.GetChild(1).GetChild(1).gameObject);
        list[0].GetComponentInChildren<Button>().onClick.AddListener(Music);
        list[1].GetComponentInChildren<Button>().onClick.AddListener(SFX);
    }
    private void OnEnable()
    {
        isMusic = GameManager.Instance.GetMusic()==0?true:false;
        isSFX = GameManager.Instance.GetSFX()==0?true:false;
        if (isMusic) list[0].GetComponentInChildren<Image>().sprite = on;
        else list[0].GetComponentInChildren<Image>().sprite = off;
        if (isSFX) list[1].GetComponentInChildren<Image>().sprite = on;
        else list[1].GetComponentInChildren<Image>().sprite = off;
    }

    private void Music()
    {
        isMusic = !isMusic;
        if (isMusic) list[0].GetComponentInChildren<Image>().sprite = on;
        else list[0].GetComponentInChildren<Image>().sprite=off;
        GameManager.Instance.SetMusic(isMusic ? 0 : 1);
        
    }
    private void SFX()
    {
        isSFX = !isSFX;
        if (isSFX) list[1].GetComponentInChildren<Image>().sprite = on;
        else list[1].GetComponentInChildren<Image>().sprite = off;
        GameManager.Instance.SetSFX(isSFX ? 0 : 1);
    }
}
