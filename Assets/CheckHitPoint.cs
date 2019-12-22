using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yukidango.BarrageShooting.Boss;
using Yukidango.BarrageShooting.Mob;

public class CheckHitPoint : MonoBehaviour {
	
	public static void checkHP(EnemyMobControl1 e,double hitPoint) { 
		if (hitPoint <= 0) Destroy(e.gameObject);
	}
	
	public static void checkHP(EnemyMobControl2 e,double hitPoint) { 
		if (hitPoint <= 0) Destroy(e.gameObject);
	}
	
	public static void checkHP(CpControl c,double hitPoint) { 
		if (hitPoint <= 0) Destroy(c.gameObject);
	}
	
	public static void checkHP(BossController b,double hitPoint) { 
		if (hitPoint <= 0) Destroy(b.gameObject);
	}
}
