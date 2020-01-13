using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    public static int score;
    
    public static void scoreCount() {
        score+=10;
    }

    public static void timeToScore(int timeScore)
    {
        score += timeScore;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
