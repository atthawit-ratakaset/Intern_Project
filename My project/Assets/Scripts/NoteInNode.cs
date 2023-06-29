using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteInNode : MonoBehaviour
{
    public int time;
    public bool open;
    public GameObject obj;
    public string nameEndtarget;
    public string endtarget;
    DataID data;
    

    private void Start()
    {
        GetID(nameEndtarget);
        if (endtarget == "B1")
        {
            obj.transform.Rotate(0f, 0f, -135f);
        }
        else if (endtarget == "B2")
        {
            obj.transform.Rotate(0f, 0f, 135f);
        }
        else if (endtarget == "B3")
        {
            obj.transform.Rotate(0f, 0f, -90f);
        }
        else if (endtarget == "B4")
        {
            obj.transform.Rotate(0f, 0f, 90f);
        }
        else if (endtarget == "B5")
        {
            obj.transform.Rotate(0f, 0f, 305f);
        } 
        else if (endtarget == "B6")
        {
            obj.transform.Rotate(0f, 0f, -305f);

        }
    }

    public void GetID(string target)
    {
        data = Database.GetID(target);
        endtarget = data.IDObject;
    }
    public string GetTargetEnd()
    {
        return endtarget;
    }

    private void OnDisable()
    {
        open = false;
    }

    private void OnEnable()
    {
        open = true;
    }
}
