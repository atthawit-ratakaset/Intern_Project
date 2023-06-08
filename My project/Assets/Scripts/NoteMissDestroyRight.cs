using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMissDestroyRight : MonoBehaviour
{
    GameObject obj;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "NotesRight")
        {
            obj = other.gameObject;
            GameControl.instance.HpDecrease();
            Score.instance.ScoreCalculationCase(Score.GetScore.Miss);
            Score.instance.ScoreCalculationCase(Score.GetScore.ResetCombo);
            Destroy(obj);
        }
    }

    void ShowScore()
    {
        Score.instance.ShowScore();
    }

}
