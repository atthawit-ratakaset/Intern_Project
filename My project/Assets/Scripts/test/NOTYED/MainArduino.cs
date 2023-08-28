using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;

public class MainArduino : MonoBehaviour
{
    private SerialPort sp = new SerialPort("\\\\.\\COM5", 115200);
    public Action<int> playButtons;
    public List<UpAreaClick> buttonTest;

    private void Start()
    {
        sp.Open();
        Debug.Log("open");
        sp.ReadTimeout = 1;
        playButtons += FindButtonsPlay;
    }

    private void FindButtonsPlay(int buttonId)
    {
        //UpAreaClick button = buttonTest.Find(s => s.id == buttonId);
       // button.OnPointerDownDelegate();
    }

    private void Update()
    {
        if (sp.IsOpen)
        {
            try
            {
                if (sp.ReadByte() == 1)
                {
                    playButtons.Invoke(1);
                }
                if (sp.ReadByte() == 2)
                {
                    playButtons.Invoke(2);
                }
                if (sp.ReadByte() == 3)
                {
                    playButtons.Invoke(3);
                }
            }
            catch (System.Exception)
            {
                
            }
        }
    }
}