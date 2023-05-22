using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBar : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    public HealthBar healthBar;
    public static HpBar instance;
    bool loseHp;

    void Awake() {
        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        loseHp = false;
    }

    void Update() {
        if (loseHp == true) {
            HpDecrease();
            loseHp = false;
        }
    }

    public void HpDecrease(int damage = 10) {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0) {
            this.Wait(1f, ShowScore);
            loseHp = false;
            MusicScript.instance.DestroyMusic();
        }
    }   

    void ShowScore() {
        Score.instance.ShowScore();
    }

    public void LoseHp() {
        loseHp = true;
    }
}
