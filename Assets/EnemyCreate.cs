using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yukidango.BarrageShooting.Mob;
using Random = UnityEngine.Random;

public class EnemyCreate : MonoBehaviour
{
	private float randomX;

	public GameObject enemyPrefab1,enemyPrefab2,bossPrefab;
	public Boolean bossCreate = true;
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
	    if (ScoreCount.score < 100)
	    {
		    if (Time.frameCount % 60 == 0)
		    {
			    for (int i = 0; i < 4; i++)
			    {
				    createMob1();
			    }

			    createMob2();
		    }
	    }else {
		    if (bossCreate)
		    {
			    GameObject boss = Instantiate(bossPrefab, new Vector3(0, 7.0f, 0), Quaternion.identity);
			    bossCreate = false;
		    }   
	    }
    }

	private void createMob1() 
	{
		randomX = Random.Range(-6.0f, 6.0f);
		GameObject enemy1 = Instantiate(enemyPrefab1,
			new Vector3(this.randomX, 5.0f, 0.0f), Quaternion.identity);
	}

	private void createMob2()
	{
		randomX = Random.Range(-6.0f, 6.0f);
		var aim = CpControl.cpPosition;
			GameObject enemy2 = Instantiate(enemyPrefab2, 
			new Vector3(this.randomX, 5.0f, 0.0f),Quaternion.identity);
	}
	protected double getRadian(double x, double y, double x2, double y2) {
		return Math.Atan2(y2 - y,x2 - x);
	}

	protected float toDegrees(double radian) {
		return (float) (radian * (180 / Math.PI));
	}
}
