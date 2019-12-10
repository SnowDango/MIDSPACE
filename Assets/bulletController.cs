using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update () { 
	    transform.Translate (0, 0.2f, 0);
	    if (transform.position.y > 5) { 
		    Destroy (gameObject);
	    }
	}
    void OnTriggerEnter2D(Collider2D coll) {
	    if (coll.gameObject.tag == "EnemyObject") {
		    enemyController.HitPoint.hitPoint -= 1;
		    Destroy(gameObject);
	    }
    }
}
