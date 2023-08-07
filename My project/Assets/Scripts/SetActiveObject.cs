using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetActiveObject : MonoBehaviour
{
    public GameObject selectMusic, uiSelectMusic, uiButton, update, flashSale, modeQuit, selectButton;
    void Start()
    {
        
    }

    public void Play()
    {
        uiButton.SetActive(false);
        update.SetActive(false);
        flashSale.SetActive(false);
        selectMusic.SetActive(true);
        uiSelectMusic.SetActive(true);
    }

    public void ModeQuit()
    {
        modeQuit.SetActive(false);
        selectButton.SetActive(false);

    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
