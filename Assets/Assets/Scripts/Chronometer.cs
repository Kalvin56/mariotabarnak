using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Chronometer : MonoBehaviour
{
    public TMP_Text timeText;

    public PlayerHealth playerHealth;

    public float time;



    void Update()
    {
        if(playerHealth.currentHealth > 0) 
        {
        time += Time.deltaTime;

        var minutes = Mathf.Floor(time / 60); //Divide the guiTime by sixty to get the minutes.
        var seconds = time % 60;//Use the euclidean division for the seconds.
        var fraction = (time * 100) % 100;

        //update the label value
        timeText.text = string.Format("{0:00} : {1:00} : {2:00}", minutes, seconds, fraction);
        }
    }
}
