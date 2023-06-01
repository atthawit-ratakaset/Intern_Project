using UnityEngine;


public class NoteMissDestroy : MonoBehaviour
{   
    GameObject obj;
   
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Notes" || other.gameObject.tag == "LastNote") {
            obj = other.gameObject;
            GameControl.instance.HpDecrease();
            Score.instance.ScoreCalculationCase(Score.GetScore.Miss);
            Score.instance.ScoreCalculationCase(Score.GetScore.ResetCombo);
            Destroy(obj);
        }
    }

    void ShowScore() {
        Score.instance.ShowScore();
    }

}
