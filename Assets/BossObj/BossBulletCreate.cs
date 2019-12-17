using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;


namespace Yukidango.BarrageShooting.Boss
{

    public struct BulletControlData
    {
        public float x;
        public float y;
    }

    public class BossBulletCreate : BossController
    {

        private static Boolean circleBulletMode = true;
        private static int circleBulletDegrees = 0;
        private static List<float> absDegrees;

        public static void twoLineBullet(double frameCount, BossController b)
        {
            if (frameCount % 10 == 0)
            {
                absDegrees = new List<float>() {-1.3f, 1.3f};
                for (int i = 0; i < absDegrees.Count; i++)
                {
                    fireBullet(b, absDegrees[i], -1.0f, (float) ToRadian(-90));
                }
            }
        }

        public static void circleBullet(double frameCount, BossController b)
        {

            if (frameCount % 4 == 0)
            {
                absDegrees = new List<float>() {0, 90, 180, -90};
                for (int i = 0; i < absDegrees.Count; i++)
                {
                    fireBullet(b, (float) (1.6f * Math.Cos(ToRadian(absDegrees[i] + circleBulletDegrees))),
                        (float) (1.6f * Math.Sin(ToRadian(absDegrees[i] + circleBulletDegrees))),
                        (float) ToRadian(absDegrees[i] + circleBulletDegrees));
                }
            }

            circleBulletDegrees += 8;
        }

        public static void parallelCircleBullet(double frameCount, BossController b)
        {

            if (frameCount % 4 == 0)
            {
                absDegrees = new List<float>() {0, 90, 180, -90};
                for (int i = 0; i < absDegrees.Count; i++)
                {
                    fireBullet(b, (float) (1.6f * Math.Cos(ToRadian(absDegrees[i] + circleBulletDegrees))),
                        (float) (1.6f * Math.Sin(ToRadian(absDegrees[i] + circleBulletDegrees))),
                        (float) ToRadian(absDegrees[i] + circleBulletDegrees));
                }

                absDegrees = new List<float>() {45, 135, -135, -45};
                for (int i = 0; i < absDegrees.Count; i++)
                {
                    fireBullet(b, (float) (1.6f * Math.Cos(ToRadian(absDegrees[i] - circleBulletDegrees))),
                        (float) (1.6f * Math.Sin(ToRadian(absDegrees[i] - circleBulletDegrees))),
                        (float) ToRadian(absDegrees[i] - circleBulletDegrees));
                }

                circleBulletDegrees += 8;
            }

        }

        public static void fireBullet(BossController b, float x, float y, float data)
        {
            var position = b.transform.position;
            GameObject shot = Object.Instantiate(b.enemyBulletPrefab,
                new Vector3(position.x + x, position.y + y, position.z),
                Quaternion.FromToRotation(Vector3.zero, new Vector3(x, y)));
            EnemyBulletController s = shot.GetComponent<EnemyBulletController>();
            s.bulletData(data);
        }

        // public void parallelCircleBullet(double circleBulletDegrees )
        public static double ToRadian(double angle)
        {
            return (double) (angle * Math.PI / 180);
        }
    }
}