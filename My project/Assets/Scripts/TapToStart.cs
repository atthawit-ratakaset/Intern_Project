using UnityEngine;

public class TapToStart : MonoBehaviour
{
    public GameObject tapToStart;
    void Update()
    {
        MenuScene();
    }

    void MenuScene()
    {
        if (Input.GetMouseButtonDown(0))
        {
            tapToStart.SetActive(false);
        }
    }
}
