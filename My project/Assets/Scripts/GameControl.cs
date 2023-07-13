using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;



public class GameControl : MonoBehaviour 
{   
    [SerializeField] GameObject CheckHp;
    public TypesNote types;
    List<NoteData> NotesEasy = new List<NoteData>();
    List<NoteData> NotesNormal = new List<NoteData>();
    List<NoteData> NotesHard = new List<NoteData>();
    List<NoteData> NotesEvent = new List<NoteData>();
    public static GameControl instance;
    public SpriteRenderer borderGame;
    bool haveHp = false;
    

    public int maxHealth = 100;
    int currentHealth;
    public HealthBar healthBar;

    public float musicPlayTime;

    [HideInInspector]
    public int getMode;

    [HideInInspector]
    public bool eventTime;
    
    float speed;
    void Awake() {
        instance = this;
        NotesEasy = MusicButton.get.Easy;
        NotesNormal = MusicButton.get.Normal;
        NotesHard = MusicButton.get.Hard;
        getMode = MenuButton.instance.selectMode;
        NotesEvent = MusicButton.get.Event;

    }

    void Start()
    {
        GameModeCheck();
        HpSetAtStart(); 
        MusicTimeCount();
        
    }

    void MusicTimeCount()
    {
        if (eventTime == true)
        {
            if (musicPlayTime < 3)
            {
                borderGame.color = Color.green;
                for (int i = 0; i < NotesHard.Count; i++)
                {

                    if (i == 0)
                    {
                        speed = -MusicButton.get.eventSpeed;
                    }
                    else if (i == 1)
                    {
                        speed = MusicButton.get.eventSpeed;
                    }
                    var note = Instantiate(NotesEvent[i]);
                    note.gameObject.AddComponent<NoteSpeedUp>().setSpeed(speed);
                }
                eventTime = false;
                musicPlayTime += 5;
                //borderGame.color = Color.green;

            }
        }
        if (musicPlayTime > 0)
        {   
            
            musicPlayTime--;
            Invoke("MusicTimeCount", 1.0f);
        }
        else
        {
            this.Wait(2f, ShowScore);
            MusicScript.instance.StopMusic();

        }
    }

    void GameModeCheck()
    {
        if (getMode == 2)
        {

            for (int i = 0; i < NotesHard.Count; i++)
            {

                if (i == 0)
                {
                    speed = -MusicButton.get.hardSpeed;
                }
                else if (i == 1)
                {
                    speed = MusicButton.get.hardSpeed;
                }
                var note = Instantiate(NotesHard[i]);
                note.gameObject.AddComponent<NoteSpeedUp>().setSpeed(speed);
                
            }
            haveHp = true;
            CheckHp.SetActive(true);
            musicPlayTime = MusicButton.get.timerHard + MusicButton.get.delay;

        }
        else if (getMode == 1)
        {
            
            for (int i = 0; i < NotesNormal.Count; i++)
            {

                if (i == 0)
                {
                    speed = -MusicButton.get.normalSpeed;
                }
                else if (i == 1)
                {
                    speed = MusicButton.get.normalSpeed;
                }
                var note = Instantiate(NotesNormal[i]);
                note.gameObject.AddComponent<NoteSpeedUp>().setSpeed(speed);
            }
            haveHp = false;
            CheckHp.SetActive(false);
            musicPlayTime = MusicButton.get.timerNormal + MusicButton.get.delay;

        } else if (getMode == 0)
        {

            for (int i = 0; i < NotesEasy.Count; i++)
            {

                if (i == 0)
                {
                    speed = -MusicButton.get.easySpeed;
                }
                else if (i == 1)
                {
                    speed = MusicButton.get.easySpeed;
                }
                var note = Instantiate(NotesEasy[i]);
                note.gameObject.AddComponent<NoteSpeedUp>().setSpeed(speed);
            }
            haveHp = false;
            CheckHp.SetActive(false);
            musicPlayTime = MusicButton.get.timerEasy + MusicButton.get.delay;

        }
    }


    public void HpDecrease(int damage = 10)
    {
        if (haveHp)
        {
            
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            if (currentHealth <= 0)
            {
                this.Wait(1f, ShowScore);
                
                MusicScript.instance.StopMusic();
            }
        }
       
    }
   
    
    void HpSetAtStart()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        
    }

    void ShowScore()
    {
        Score.instance.ShowScore();
    }

    public void EventTime()
    {
        if (Score.instance.TotalScore >= 500)
        {
            eventTime = true;
        }
    }

}
