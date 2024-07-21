using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUnlock : MonoBehaviour
{
    List<Button> buttonList = new List<Button>();
    private void OnEnable()
    {
        buttonList.Clear();
        buttonList.AddRange(transform.GetChild(1).GetComponentsInChildren<Button>());
        foreach (Button button in buttonList)
        {
            int level = int.Parse(button.transform.gameObject.name);
            button.onClick.AddListener(()=> UI.instance.LoadLevel(level));
        }
        for (int i = 0; i < GameManager.Instance.GetLevelUnlock(); i++)
        {
            buttonList[i].interactable = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
