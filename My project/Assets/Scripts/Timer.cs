using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public TMP_Text timerTextMinutes;
    public TMP_Text timerTextSeconds;


    private float timerTime;
    private bool isRunning;

    void Start()
    {
        isRunning = true;
        if (MusicButton.get != null)
        {
            if (MenuButton.selectMode == 0)
            {
                timerTime = MusicButton.get.timerEasy + MusicButton.get.delay;
            } else if (MenuButton.selectMode == 1)
            {
                timerTime = MusicButton.get.timerNormal + MusicButton.get.delay;
            } else if (MenuButton.selectMode == 2)
            {
                timerTime = MusicButton.get.timerHard + MusicButton.get.delay;
            }
        }
    }

    void Update()
    {   
        if (MusicButton.get != null)
        {
            if (timerTime < 0)
            {
                timerTime = 0;
            }
            else if (timerTime > 0)
            {
                timerTime -= Time.deltaTime;
            }
        } else
        {
            timerTime += Time.deltaTime;
        }

        int minutesInt = (int)timerTime / 60;
        int secondsInt = (int)timerTime % 60;

        if (isRunning)
        {
            timerTextMinutes.text = (minutesInt < 10) ? "0" + minutesInt : minutesInt.ToString();
            timerTextSeconds.text = (secondsInt < 10) ? "0" + secondsInt : secondsInt.ToString();
        }
    }
}
