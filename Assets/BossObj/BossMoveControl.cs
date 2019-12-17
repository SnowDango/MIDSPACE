using System;
using Random = UnityEngine.Random;

namespace Yukidango.BarrageShooting.Boss
{
	public class BossMoveControl {

		public static Boolean side = true;

		public static void twoLineMove(BossController e, double frameCount) {
			
			if (side){
				e.transform.Translate(0.05f, 0, 0);
			}else {
				e.transform.Translate(-0.05f, 0, 0);
			}

			

			if (e.transform.position.x >= 2.45 || e.transform.position.x <= -2.45) {
				sideInversion(); 
			}else if (frameCount % 30 == 0) {
				int sideMode = Random.Range(0, 4);
				if (sideMode == 0) {
					sideInversion();
				}
			}
		}

		public static void sideInversion() {
			if (side) {
				side = false;
			}else {
				side = true;
			}
		}
	}
}