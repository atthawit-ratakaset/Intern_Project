using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContinousGame : MonoBehaviour
{   
    public static ContinousGame instance;
    public TMP_Text countDownText;
    int countDownTime = 3;

    void Awake() {
        instance = this;
    }  

    void Start() {
    }

    IEnumerator CountDownToStart() {
        while (countDownTime > 0) {
            countDownText.text = countDownTime.ToString();

            yield return new WaitForSecondsRealtime(1f);

            countDownTime-- ;
        }

        yield return new WaitForSecondsRealtime(1f);

        countDownText.gameObject.SetActive(false);
        Time.timeScale = 1f;
        AudioSource[] audio = FindObjectsOfType<AudioSource>();
        foreach (AudioSource a in audio) {
            a.Play();
        }
    }

    public void Coutinous() {
        countDownTime = 3;
        countDownText.gameObject.SetActive(true);
        StartCoroutine(CountDownToStart());
    }

}
