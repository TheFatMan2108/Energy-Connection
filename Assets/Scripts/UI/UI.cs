using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UI : MonoBehaviour,IPointerClickHandler
{   
    public static UI instance {  get; private set; }

    private void Awake()
    {
        if(instance == null)instance = this;
        else Destroy(gameObject);
    }
    public void PlayerAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        transform.GetChild(1).gameObject.SetActive(true);
        if(transform.GetChild(2).gameObject.activeInHierarchy) transform.GetChild(2).gameObject.SetActive(false);
    }
    public void LoadLevel(int level)
    {
        SceneManager.LoadScene("1-"+level);
    }
    public void Setting()
    {
        transform.GetChild(2).gameObject.SetActive(true);
        if (transform.GetChild(1).gameObject.activeInHierarchy) transform.GetChild(1).gameObject.SetActive(false);
    }

    public void Exit()=>Application.Quit();

    public void OnPointerClick(PointerEventData eventData)
    {
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);
    }
}
