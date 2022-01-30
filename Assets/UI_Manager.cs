using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public Sprite[] life_img;
    public PlayerController Chicho;
    public Image TimePower;

    void Update()
    {
        if (Chicho.timePower == 0)
        {
            TimePower.sprite = life_img[6];
        }
        else if (Chicho.timePower == 0.5f)
        {
            TimePower.sprite = life_img[5];
        }
        else if (Chicho.timePower == 1f)
        {
            TimePower.sprite = life_img[4];
        }
        else if (Chicho.timePower == 1.5f)
        {
            TimePower.sprite = life_img[3];
        }
        else if (Chicho.timePower == 2f)
        {
            TimePower.sprite = life_img[2];
        }
        else if (Chicho.timePower == 2.5f)
        {
            TimePower.sprite = life_img[1];
        }
        else if (Chicho.timePower == 3f)
        {
            TimePower.sprite = life_img[0];
        }
    }
}
