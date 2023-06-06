using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour 
{   
    [SerializeField] GameObject CheckHp;
    List<GameObject> Notes;
    public static GameControl instance;
    bool haveHp = false;

    public int maxHealth = 100;
    int currentHealth;
    public HealthBar healthBar;

    public float musicPlayTime;

    [HideInInspector]
    public int getMode;

    void Awake() {
        instance = this;
        Notes = MusicButton.get.Notes;
        getMode = MenuButton.instance.selectMode;
        GameModeCheck();

    }

    void Start()
    {
        Debug.Log(getMode);
        Instantiate(Notes[getMode], Notes[getMode].transform.position, Quaternion.identity);
        HpSetAtStart();
        MusicTimeCount();

    }

    void MusicTimeCount()
    {
        if(musicPlayTime > 0)
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
            haveHp = true;
            CheckHp.SetActive(true);
            musicPlayTime = MusicButton.get.timerHard + MusicButton.get.delay;
        }
        else if (getMode == 1)
        {
            haveHp = false;
            CheckHp.SetActive(false);
            musicPlayTime = MusicButton.get.timerNormal + MusicButton.get.delay;
        } else
        {
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
}
