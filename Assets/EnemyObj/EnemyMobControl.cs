using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yukidango.BarrageShooting.Mob
{
	public class EnemyMobControl : MonoBehaviour
	{

		public class HitPoint
		{
			public static int hitPoint = 5; 
		}
		
		public float dx;
		public float dy;
		public Boolean start = true;
		public GameObject enemyBulletPrefab;

		/*public void enemyData(double angels)
		{
			dx = (float) (0.03 * Math.Cos(angels));
			dy = (float) (0.03 * Math.Sin(angels));
		}
		*/

		// Start is called before the first frame update
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{
			dy = -0.03f;
			transform.Translate(dx, dy, 0);

			if (transform.position.y < -5 || transform.position.y > 5
				|| transform.position.x > 6.5 || transform.position.x < -6.5) {
				Destroy(gameObject);
			}

			if (Time.frameCount % 60 == 0)
			{
				fireBullet(this, 0, 0.05f, (float) ToRadian(-90));
			}
			
		}

		public static void fireBullet(EnemyMobControl e, float x, float y, float data)
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
				EnemyMobControl.HitPoint.hitPoint -= 1;
				CheckHitPoint.checkHP(this,EnemyMobControl.HitPoint.hitPoint);
			}
		}
	}
}