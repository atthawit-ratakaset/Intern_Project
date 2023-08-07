using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MusicButton : MonoBehaviour
{
    public static MusicButton instance;
    public GetValue musicData;
    public static GetValue get;
    public TMP_Text songName;
    public Image image;
    public GameObject setTrueObj1, setTrueObj2;



    void Start()
    {   
        instance = this;
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
        btn.onClick.AddListener(delegate () { SetDataMusic(musicData); });
        image.gameObject.GetComponent<Image>().sprite = musicData.image;
        songName.text = musicData.songName.ToString();
        
    }

    public void SetDataMusic(GetValue getValue)
    {   
        get = getValue;

    }

    public void OnClick()
    {
        setTrueObj1.SetActive(true);
        setTrueObj2.SetActive(true);

    }

}
