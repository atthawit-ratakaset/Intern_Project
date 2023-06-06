using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetActiveObject : MonoBehaviour
{
    public GameObject mainMenu, popUpMode;
    void Start()
    {
        mainMenu.SetActive(true);
        popUpMode.SetActive(false);
    }

    public void ReturnMenuSong()
    {
        popUpMode.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
