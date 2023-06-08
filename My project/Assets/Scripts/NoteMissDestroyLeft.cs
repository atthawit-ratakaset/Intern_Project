using UnityEngine;


public class NoteMissDestroyLeft : MonoBehaviour
{   
    GameObject obj;
   
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "NotesLeft") {
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
