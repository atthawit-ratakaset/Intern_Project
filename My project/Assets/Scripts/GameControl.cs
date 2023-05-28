using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{   
    [SerializeField] GameObject CheckHp;
    List<GameObject> Notes;
    public static GameControl instance;
    bool haveHp = false;
    int getMode;

    void Awake() {
        instance = this;
        Notes = GetValue.Notes;
        getMode = GetValue.mode;

        if (getMode == 2) {
            haveHp = true;
        } else {
            haveHp = false;
        }

    }
    // Start is called before the first frame update
    void Start()
    {   
        Instantiate(Notes[getMode], Notes[getMode].transform.position, Quaternion.identity);
        if (haveHp) {
            CheckHp.SetActive(true);

        } else {
            CheckHp.SetActive(false);
        }

    }

    public void CheckScene() {
        if (haveHp) {
            HpBar.instance.LoseHp();
        }
    }
    
}
