using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

public class ScoreBoard : MonoBehaviour
{
    public Text scoreText;
    public void Start() 
    {
        DisplayScores();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("HomeMenuScene");
    }

    private void DisplayScores()
    {
        var scores = SimpleDB.getScores();

        // Convertir les temps en secondes et trier la liste
        scores = scores.OrderByDescending(entry => ConvertTimeToSeconds(entry.temps)).ToList();

        // Construisez une chaîne de texte avec les scores
        string scoresText = "Scores:\n";
        foreach (var entry in scores)
        {
            scoresText += $"{entry.name}: {entry.temps}\n";
        }

        // Mettez à jour le Text sur le Canvas
        if (scoreText != null)
        {
            scoreText.text = scoresText;
        }
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
