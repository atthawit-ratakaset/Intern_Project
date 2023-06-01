using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallMenuScene : MonoBehaviour
{
    public GameObject menuScene;
    void Start()
    {
        Instantiate(menuScene, menuScene.transform.position, Quaternion.identity);
    }

}
