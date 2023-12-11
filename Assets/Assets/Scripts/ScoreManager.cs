using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;
public class ScoreManager : MonoBehaviour
{
    private ScoreData sd;

    void Awake()
    {
        sd = new ScoreData();
    }

    public IEnumerable<Score> GetHighScores()
    {
        return sd.scores.OrderByDescending(entry => ConvertTimeToSeconds(entry.time)).ToList();
    }

    public void AddScore(Score score)
    {
        sd.scores.Add(score);
    }

    private float ConvertTimeToSeconds(string timeString)
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