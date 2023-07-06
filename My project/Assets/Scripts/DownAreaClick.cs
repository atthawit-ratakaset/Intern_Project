using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DownAreaClick : MonoBehaviour
{
    public DownButtonGame button;
    public ParticleSystem particEffect;
    public AudioSource soundFX;

    void Start()
    {
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((data) => { OnPointerDownDelegate((PointerEventData)data); });
        trigger.triggers.Add(entry);
    }

    public void OnPointerDownDelegate(PointerEventData data)
    {
        soundFX.Play();
        particEffect.Play();
        if (button.hit == true)
        {
            if ((button.subNote1 == true && button.subNote2 == true && button.subNote3 == true))
            {
                Score.instance.ScoreCalculationCase(Score.GetScore.Perfect);
                Score.instance.ScoreCalculationCase(Score.GetScore.Combo);
            }
            else if ((button.subNote1 == true && button.subNote2 == false && button.subNote3 == false) ||
                      (button.subNote3 == true && button.subNote2 == false && button.subNote3 == false))
            {
                Score.instance.ScoreCalculationCase(Score.GetScore.Bad);
                Score.instance.ScoreCalculationCase(Score.GetScore.Combo);
            }
            else
            {
                Score.instance.ScoreCalculationCase(Score.GetScore.Good);
                Score.instance.ScoreCalculationCase(Score.GetScore.Combo);
            }
            button.DestroyNote();

        }
        else if (button.noteSp1 == true)
        {

            button.hp -= 1;
            Score.instance.ScoreCalculationCase(Score.GetScore.Combo);
            Score.instance.ScoreCalculationCase(Score.GetScore.Perfect);
            if (button.hp == 0)
            {
                button.DestroyNote();
            }
            else if (button.hp == 1)
            {
                button.spiteRenderer.sprite = button.sp2;

            }
        }
        else if (button.noteSp2 == true)
        {
            Score.instance.ScoreCalculationCase(Score.GetScore.Miss);
            Score.instance.ScoreCalculationCase(Score.GetScore.ResetCombo);
            button.DestroyNote();
        }
    }
}
