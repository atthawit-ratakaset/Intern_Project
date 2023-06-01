using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPopUp : MonoBehaviour
{
    public GetValue[] getValue;

    void Start()
    {
        getValue = Resources.LoadAll<GetValue>("Music");
    }

  


}
