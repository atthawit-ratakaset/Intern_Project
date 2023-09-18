using UnityEngine;

public class CallMenuScene : MonoBehaviour
{
    public GameObject menuScene;

    void Start()
    {
        GameObject a = new GameObject();
        Instantiate(menuScene, menuScene.transform.position, Quaternion.identity);


    }

}
