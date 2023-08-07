using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObject : MonoBehaviour
{
    public GameObject menuScene, selectMusicScene;

    public void Play()
    {
        menuScene.SetActive(false);
        selectMusicScene.SetActive(true);
    }

    public void ReturnLobby()
    {
        menuScene.SetActive(true);
        selectMusicScene.SetActive(false);
    }
}
