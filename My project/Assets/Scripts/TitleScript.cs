using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TitleScript : MonoBehaviour
{
    public GameObject tapToStart, nameSetting, logoGame, resetGame;
    public TMP_InputField enterName;
    bool haveId = false;
    PlayerData playerData;


    [Header("LoadScene")]
    public GameObject load;
    public Image loadImage;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Playerdata"))
        {
            haveId = false;

        }
        else
        {
            haveId = true;

        }
        tapToStart.SetActive(true);
        logoGame.SetActive(true);
        resetGame.SetActive(true);
        nameSetting.SetActive(false);
        Debug.Log(haveId);
    }

    public void Play()
    {
        if (haveId == false)
        {
            tapToStart.SetActive(false);
            logoGame.SetActive(false);
            nameSetting.SetActive(true);
            resetGame.SetActive(false);

        }
        else if (haveId == true)
        {
            tapToStart.SetActive(false);
            resetGame.SetActive(false);
            StartCoroutine("Load");

        }

    }

    public void PlayScene()
    {

        if (haveId == false)
        {
            tapToStart.SetActive(false);
            logoGame.SetActive(true);
            nameSetting.SetActive(false);
            if (enterName.text != "")
            {
                playerData = ServerApi.Load();
                playerData.playerName = enterName.text;
                ServerApi.Save();
                StartCoroutine("Load");

            } else
            {
                playerData = ServerApi.Load();
                playerData.playerName = "Tester001";
                ServerApi.Save();
                StartCoroutine("Load");
            }

        }
        else
        {
            StartCoroutine("Load");

        }




    }

    public IEnumerator Load()
    {
        load.SetActive(true);
        AsyncOperation loadScene = SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Single);
        while (!loadScene.isDone)
        {
            loadImage.fillAmount = loadScene.progress;
            yield return null;
        }
    }


    public void DeleteDataPref()
    {
        if (haveId == false)
        {
            Debug.Log("Don't have data to delete!!");
        } else
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
