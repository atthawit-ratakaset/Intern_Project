using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public DataID dataID;
    string ID;

    private void Awake()
    {
        ID = dataID.IDObject;
    }
}
