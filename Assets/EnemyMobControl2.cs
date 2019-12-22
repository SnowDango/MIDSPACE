using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yukidango.BarrageShooting.Mob
{
	public class EnemyMobControl2 : MonoBehaviour
	{

		public class HitPoint
		{
			public static int hitPoint = 3; 
		}
		
		public float dx;
		public float dy;
		public Boolean start = true;
		public GameObject enemyBulletPrefab;
		float TimeCount　= 15;

		public void enemyData(double angels)
		{
			dx = (float) (0.05 * Math.Cos(angels));
			dy = (float) (0.05 * Math.Sin(angels));
			
		}
		// Start is called before the first frame update
		void Start() {
		}

		// Update is called once per frame
		void Update()
		{
			TimeCount -= Time.deltaTime;
			

			transform.Translate(dx, dy, 0);

				if (transform.position.y < -5 || transform.position.y > 5
					|| transform.position.x > 6.5 || transform.position.x < -6.5)
				{
					Destroy(gameObject);
				}

		}

		public static double ToRadian(double angle)
		{
			return (double) (angle * Math.PI / 180);
		}


		void OnTriggerEnter2D(Collider2D coll) {
			if (coll.gameObject.CompareTag("playerBullet")) {
				HitPoint.hitPoint -= 1;
				CheckHitPoint.checkHP(this,HitPoint.hitPoint);
			} if (coll.gameObject.CompareTag("Player")) {
				Destroy(gameObject);
			}
		}
	}
}