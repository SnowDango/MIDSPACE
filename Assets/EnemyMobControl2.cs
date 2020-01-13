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

		private float dx, dy, direction;
		public GameObject enemyBulletPrefab;
		float TimeCount　= 15;
		private float speed = 0.075f;
		private double bulletAngles;

		public void setBulletAngles(double angles)
		{
			bulletAngles = angles;
		}

		// Start is called before the first frame update
		void Start()
		{
			var diff = (CpControl.cpPosition - transform.position ).normalized;
			transform.rotation = Quaternion.FromToRotation( Vector3.down,  diff);
		}

		// Update is called once per frame
		void Update()
		{
			TimeCount -= Time.deltaTime;

			transform.Translate(0, -speed, 0);

				if (transform.position.y < -5 || transform.position.y > 5
					|| transform.position.x > 6.5 || transform.position.x < -6.5)
				{
					Destroy(gameObject);
				}
			if (Time.frameCount % 120 == 0)
			{
				fireBullet(this, 0, 0.05f, (float) bulletAngles);
			}
			
		}

		public static void fireBullet(EnemyMobControl2 e, float x, float y, float data)
		{
			var position = e.transform.position;
			GameObject shot = Instantiate(e.enemyBulletPrefab,
				new Vector3(position.x + x, position.y + y, position.z),
				Quaternion.FromToRotation(Vector3.zero, new Vector3(x, y)));
			EnemyBulletController s = shot.GetComponent<EnemyBulletController>();
			s.bulletData(data);
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