using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using Yukidango.BarrageShooting.Boss;

public class UIchanger : MonoBehaviour {
    // Start is called before the first frame update
    public GameObject enemyHp;

    void Start() {
        this.enemyHp = GameObject.Find("enemyHP");
    }

    // Update is called once per frame
    void Update() {
        enemyHp.GetComponent<Text>().text = "enemy HP: " + BossController.HitPoint.hitPoint.ToString() ;
    }
}
