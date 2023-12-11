using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;
[Serializable]
public class Score
{
    public string name;
    public string time;

    public Score(string name, string time)
    {
        this.name = name;
        this.time = time;
    }
}