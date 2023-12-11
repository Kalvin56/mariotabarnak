using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;
public class ScoreUi : MonoBehaviour
{
    public RowUi rowUi;
    public ScoreManager scoreManager;

    void Start()
    {   
        var scoreList = SimpleDB.getScores();
        scoreList = scoreList.OrderByDescending(entry => ConvertTimeToSeconds(entry.temps)).ToList();
        var i = 0;
        foreach (var entry in scoreList)
        {
            var row = Instantiate(rowUi,transform).GetComponent<RowUi>();
            row.rank.text = (i+1).ToString();
            row.name.text = entry.name;
            row.time.text = entry.temps.ToString();
            i++;
        }
    }

    float ConvertTimeToSeconds(string timeString)
    {
        string[] timeComponents = timeString.Split(':');

        // Extraire les minutes, secondes et millisecondes
        int minutes = int.Parse(timeComponents[0]);
        int seconds = int.Parse(timeComponents[1]);
        
        // Splitter les secondes et les millisecondes (format : "ss.sss")
        string[] secondComponents = timeComponents[2].Split('.');
        
        // Extraire les secondes
        int secondsPart = int.Parse(secondComponents[0]);
        
        // Extraire les millisecondes (si elles existent)
        float milliseconds = secondComponents.Length > 1 ? float.Parse(secondComponents[1]) : 0f;

        // Calculer le temps total en secondes, y compris les millisecondes
        return minutes * 60 + seconds + secondsPart + milliseconds / 1000f;
    }
}