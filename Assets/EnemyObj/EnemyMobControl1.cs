using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yukidango.BarrageShooting.Mob
{
	public class EnemyMobControl1 : MonoBehaviour
	{

		public class HitPoint
		{
			public static int hitPoint = 5;
		}

		public float dx;
		public float dy;
		public Boolean start = true;
		public GameObject enemyBulletPrefab;
		private float speed = 0.05f;

		// Start is called before the first frame update
		void Start()
		{
			dy = -1 * speed;
		}

		// Update is called once per frame
		void Update()
		{
			
			transform.Translate(dx, dy, 0);

			if (transform.position.y < -5 || transform.position.y > 5
				|| transform.position.x > 6.5 || transform.position.x < -6.5) {
				Destroy(gameObject);
			}

			if (Time.frameCount % 120 == 0)
			{
				fireBullet(this, 0, 0.05f, (float) ToRadian(-90));
			}
			
		}

		public static void fireBullet(EnemyMobControl1 e, float x, float y, float data)
		{
			var position = e.transform.position;
			GameObject shot = Instantiate(e.enemyBulletPrefab,
				new Vector3(position.x + x, position.y + y, position.z),
				Quaternion.FromToRotation(Vector3.zero, new Vector3(x, y)));
			EnemyBulletController s = shot.GetComponent<EnemyBulletController>();
			s.bulletData(data);
		}

		public static double ToRadian(double angle)
		{
			return (double) (angle * Math.PI / 180);
		}

		void OnTriggerEnter2D(Collider2D coll) {
			if (coll.gameObject.CompareTag("playerBullet"))
			{
				EnemyMobControl1.HitPoint.hitPoint -= 1;
				CheckHitPoint.checkHP(this,EnemyMobControl1.HitPoint.hitPoint);
				ScoreCount.scoreCount();
			}else if (coll.gameObject.CompareTag("Player"))
			{
				Destroy(gameObject);
			}
		}
	}
}