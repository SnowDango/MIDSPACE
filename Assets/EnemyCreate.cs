using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreate : MonoBehaviour
{


	public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
	    if (Time.frameCount % 12 == 0) {
		    float randomX = Random.Range(-6.0f, 6.0f); 
		    GameObject shot = Instantiate(enemyPrefab, 
			    new Vector3(randomX, 5.0f ,0.0f), Quaternion.identity); 
		    EnemyBulletController s = shot.GetComponent<EnemyBulletController>();
	    }
    }
}
