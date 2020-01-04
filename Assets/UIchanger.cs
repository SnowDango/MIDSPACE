using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using Yukidango.BarrageShooting.Boss;

public class UIchanger : MonoBehaviour {
    // Start is called before the first frame update

    private GameObject playerX,playerY,Score;
    void Start() {
        playerX = GameObject.Find("playerX");
        playerY = GameObject.Find("playerY");
        Score = GameObject.Find("Score");
    }

    // Update is called once per frame
    void Update() {
        this.GetComponent<Text>().text = "HitPoint: " + CpControl.HitPoint.hitPoint;
        this.GetComponent<Text>().color = Color.red;

        playerX.GetComponent<Text>().text = "playerX:" + CpControl.cpPosition.x;
        playerX.GetComponent<Text>().color = Color.red;

        playerY.GetComponent<Text>().text = "playerY:" + CpControl.cpPosition.y;
        playerY.GetComponent<Text>().color = Color.red;

        Score.GetComponent<Text>().text = "Score: " + ScoreCount.score;
        Score.GetComponent<Text>().color = Color.red;

    }
}
