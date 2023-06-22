using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeftAreaClick : MonoBehaviour
{
    public LeftButtonGame button;
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
                      (button.subNote3 == true && button.subNote2 == false && button.subNote1 == false))
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
    }
}
