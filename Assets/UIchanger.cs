using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using Yukidango.BarrageShooting.Boss;

public class UIchanger : MonoBehaviour {
    // Start is called before the first frame update
    
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        this.GetComponent<Text>().text = "HitPoint: " + CpControl.HitPoint.hitPoint;
        this.GetComponent<Text>().color = Color.red;
    }
}
