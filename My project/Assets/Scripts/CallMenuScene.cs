using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallMenuScene : MonoBehaviour
{
    public GameObject menuScene;
    void Start()
    {
        GameObject a = new GameObject();
        a.name = "Empty";
        Instantiate(menuScene, menuScene.transform.position, Quaternion.identity);


    }

}
