using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public struct BulletControlData {
    public float x;
    public float y;
}

public class EnemyBulletCreate : enemyController
{
    private static int circleBulletDegrees = 0;
    private static List<float> absDegrees;

    public static void twoLineBullet(double frameCount, enemyController e)
    {
        if (frameCount % 10 == 0)
        {
            absDegrees = new List<float>() {-1.3f,1.3f};
            for (int i = 0; i < absDegrees.Count; i++) {
                fireBullet(e, absDegrees[i], -1.0f, (float) ToRadian(-90));
            }
        }
    }
    public static void circleBullet(double frameCount,enemyController e)
    {

        if (frameCount % 4 == 0)
        {
            absDegrees = new List<float>(){0,90,180,-90};
            for (int i = 0; i < absDegrees.Count; i++) {
                fireBullet(e,(float) (1.6f * Math.Cos(ToRadian(absDegrees[i] + circleBulletDegrees))),
                    (float) (1.6f * Math.Sin(ToRadian(absDegrees[i] + circleBulletDegrees))),
                    (float)ToRadian(absDegrees[i]+circleBulletDegrees));
            }
            circleBulletDegrees += 10;
        }
    }
    public static void fireBullet(enemyController e, float x, float y, float data) {
        var position = e.transform.position;
        GameObject shot = Object.Instantiate(e.enemyBulletPrefab, 
            new Vector3(position.x + x, position.y + y, position.z), 
            Quaternion.FromToRotation(Vector3.zero, new Vector3(x, y))); 
        enemyBulletController s = shot.GetComponent<enemyBulletController>();
        s.bulletData(data);
    }
    // public void parallelCircleBullet(double circleBulletDegrees )
    public static double ToRadian(double angle) {
        return (double) (angle * Math.PI / 180);
    }
}
