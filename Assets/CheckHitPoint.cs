using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using Yukidango.BarrageShooting.Boss;
using Yukidango.BarrageShooting.DataBase;
using Yukidango.BarrageShooting.Mob;

public class CheckHitPoint : MonoBehaviour {
	
	public static void checkHP(EnemyMobControl1 e,double hitPoint) { 
		if (hitPoint <= 0) Destroy(e.gameObject);
	}
	
	public static void checkHP(EnemyMobControl2 e,double hitPoint) { 
		if (hitPoint <= 0) Destroy(e.gameObject);
	}
	
	public static void checkHP(CpControl c,double hitPoint) {
		if (hitPoint <= 0) {
			Destroy(c.gameObject);
			SceneManager.LoadScene("EndCard");
		}
	}
	
	public static void checkHP(BossController b,double hitPoint) {
		if (hitPoint <= 0)
		{
			Destroy(b.gameObject);
			DataControll dataControll = new DataControll();
			double timeScore = TimeControl.minute * 60 + TimeControl.seconds;
			ScoreCount.timeToScore((int)(timeScore * 1000));
			try
			{
				dataControll.insertDb(ScoreCount.score);
			}
			catch (Exception e)
			{
				Debug.Log("miss insert database");
			}
			finally
			{
				SceneManager.LoadScene("EndCard");
			}
		}
		
	}
}
