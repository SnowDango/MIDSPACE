using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Yukidango.BarrageShooting.Mob
{
	public class EnemyMobControl2 : MonoBehaviour
	{

		public class HitPoint
		{
			public static int hitPoint = 3; 
		}

		private float dx, dy, direction;
		public GameObject enemyBulletPrefab;
		float TimeCount　= 15;
		private float speed = 0.075f;
		
		
		// Start is called before the first frame update
		void Start()
		{
			var diff = (CpControl.cpPosition - transform.position ).normalized;
			transform.rotation = Quaternion.FromToRotation( Vector3.down,  diff);
			dy = -1 * speed;
		}

		// Update is called once per frame
		void Update()
		{
			TimeCount -= Time.deltaTime;

			transform.Translate(0, -0.075f, 0);

				if (transform.position.y < -5 || transform.position.y > 5
					|| transform.position.x > 6.5 || transform.position.x < -6.5)
				{
					Destroy(gameObject);
				}

		}

		private float ToDegrees(double angle)
		{
			return (float) (angle * Math.PI / 180);
		}


		void OnTriggerEnter2D(Collider2D coll) {
			if (coll.gameObject.CompareTag("playerBullet")) {
				HitPoint.hitPoint -= 1;
				CheckHitPoint.checkHP(this,HitPoint.hitPoint);
				ScoreCount.scoreCount();
			} if (coll.gameObject.CompareTag("Player")) {
				Destroy(gameObject);
			}
		}
	}
}