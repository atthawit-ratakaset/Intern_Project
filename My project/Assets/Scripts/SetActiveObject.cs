using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveObject : MonoBehaviour
{
    public GameObject play, credit, mainMenu, aboutUs, popUpMode;
    void Start()
    {
        play.SetActive(true);
        credit.SetActive(true);
        mainMenu.SetActive(false);
        aboutUs.SetActive(false);
        popUpMode.SetActive(false);
    }

    public void ClickPlay() 
    {
        play.SetActive(false);
        credit.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void ClickCredit() 
    {
        play.SetActive(false);
        credit.SetActive(false);
        aboutUs.SetActive(true);
    }

    public void ReturnTitleMenu()
    {
        play.SetActive(true);
        credit.SetActive(true);
        mainMenu.SetActive(false);
        aboutUs.SetActive(false);
    }

    public void ReturnMenuSong()
    {
        popUpMode.SetActive(false);
        mainMenu.SetActive(true);
    }
}
