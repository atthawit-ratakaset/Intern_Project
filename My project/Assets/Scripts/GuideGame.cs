using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideGame : MonoBehaviour
{
    public GameObject guide, page1, page2, page3, page4, page5, page6, next, back, ok;
    int whatPage = 1;

    private void Start()
    {
        CheckPage();
    }

    public void CheckPage()
    {

        if (whatPage == 1)
        {
            page1.SetActive(true);
            page2.SetActive(false);
            page3.SetActive(false);
            page4.SetActive(false);
            page5.SetActive(false);
            page6.SetActive(false);
            next.SetActive(true);
            back.SetActive(false);
            ok.SetActive(false);
        }
        else if (whatPage == 2)
        {
            page1.SetActive(false);
            page2.SetActive(true);
            page3.SetActive(false);
            page4.SetActive(false);
            page5.SetActive(false);
            page6.SetActive(false);
            next.SetActive(true);
            back.SetActive(true);
            ok.SetActive(false);
        }
        else if (whatPage == 3)
        {
            page1.SetActive(false);
            page2.SetActive(false);
            page3.SetActive(true);
            page4.SetActive(false);
            page5.SetActive(false);
            page6.SetActive(false);
            next.SetActive(true);
            back.SetActive(true);
            ok.SetActive(false);
        }
        else if (whatPage == 4)
        {
            page1.SetActive(false);
            page2.SetActive(false);
            page3.SetActive(false);
            page4.SetActive(true);
            page5.SetActive(false);
            page6.SetActive(false);
            next.SetActive(true);
            back.SetActive(true);
            ok.SetActive(false);
        }
        else if (whatPage == 5)
        {
            page1.SetActive(false);
            page2.SetActive(false);
            page3.SetActive(false);
            page4.SetActive(false);
            page5.SetActive(true);
            page6.SetActive(false);
            next.SetActive(true);
            back.SetActive(true);
            ok.SetActive(false);
        }
        else if (whatPage == 6)
        {
            page1.SetActive(false);
            page2.SetActive(false);
            page3.SetActive(false);
            page4.SetActive(false);
            page5.SetActive(false);
            page6.SetActive(true);
            next.SetActive(false);
            back.SetActive(true);
            ok.SetActive(true);
        }
    }

    public void NextPage()
    {
        whatPage += 1;
        if (whatPage == 6)
        {
            whatPage = 6;
        }
        CheckPage();
    }

    public void PreviousPage()
    {
        whatPage -= 1;
        if (whatPage == 1)
        {
            whatPage = 1;
        }
        CheckPage();
    }

    public void Finsh()
    {
        guide.SetActive(false);
        whatPage = 1;
        if (MusicButton.get != null)
        {
            MusicScript.instance.gameMusic.PlayDelayed(MusicScript.instance.musicDelay);
        }

        Time.timeScale = 1;
    }
}