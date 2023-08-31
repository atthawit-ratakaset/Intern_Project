using UnityEngine;
using UnityEngine.UI;

public class Swipe : MonoBehaviour
{
    public GameObject scrollbar;
    float scorll_pos = 0;
    float[] pos;
    

    public void Start()
    {
        
    }

    void Update()
    {

        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);
        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }

        if (Input.GetMouseButton(0))
        {
            scorll_pos = scrollbar.GetComponent<Scrollbar>().value;
        } else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (scorll_pos < pos[i] + (distance/2) && scorll_pos > pos[i] - (distance/2)) {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }

            }
        }

     

        for (int i = 0; i < pos.Length; i++)
        {
            if (scorll_pos < pos[i] + (distance / 2) && scorll_pos > pos[i] - (distance / 2))
            {
                transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1.0f, 1.0f), 0.1f);
                for (int a = 0; a < pos.Length; a++)
                {
                    if (a != i) {
                        
                        transform.GetChild(a).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(0.005f, 0.005f), 0.1f);
                        Color color = transform.GetChild(a).gameObject.GetComponent<MusicButton>().image.color;
                        
                        color.a = 0.5f;
                        transform.GetChild(a).gameObject.GetComponent<MusicButton>().image.color = color;
                        transform.GetChild(a).gameObject.GetComponent<MusicButton>().frame.SetActive(false);
                    } else
                    {
                        Color color = transform.GetChild(a).gameObject.GetComponent<MusicButton>().image.color;
                        color.a = 1f;
                        transform.GetChild(a).gameObject.GetComponent<MusicButton>().image.color = color;
                        transform.GetChild(a).gameObject.GetComponent<MusicButton>().SetDataMusic(MusicPopUp.instance.getValue.getMusicData[a]);
                    }
                }
            }
        }
    }


}
