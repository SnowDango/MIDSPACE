using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;


namespace Yukidango.BarrageShooting.Boss
{

    public class BossController : MonoBehaviour
    {

        public Boolean side = true;
        public GameObject enemyBulletPrefab;
        public static int bulletPatarn = 1;
        public Boolean move = true;
        public Boolean firstMove = true;
        public GameObject shot;

        public static class HitPoint
        {
            public static int hitPoint = 5000;
        }

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame

        public static void updateHP()
        {
            HitPoint.hitPoint -= 3;
        }

        void Update()
        {
            if (firstMove)
            {
                transform.Translate(0, -0.05f, 0);
                if (transform.position.y <= 4.0f) firstMove = false;
            }

            if (Time.frameCount % 500 == 0)
            {
                System.Random r = new System.Random(1000);
                bulletPatarn = Random.Range(0, 3);
            }

            if (bulletPatarn == 0)
            {
                BossBulletCreate.twoLineBullet(Time.frameCount, this);
                BossMoveControl.twoLineMove(this, Time.frameCount);
            }
            else if (bulletPatarn == 1)
            {
                BossBulletCreate.circleBullet(Time.frameCount, this);
                move = false;
            }
            else if (bulletPatarn == 2)
            {
                BossBulletCreate.parallelCircleBullet(Time.frameCount, this);
            }

            checkHP();
        }

        public void checkHP()
        {
            if (HitPoint.hitPoint <= 0)
            {
                Destroy(this.gameObject);
            }
        }

        public double ToRadian(double angle)
        {
            return (double) (angle * Math.PI / 180);
        }

        void OnTriggerEnter2D(Collider2D coll)
        {
            if (coll.gameObject.CompareTag("playerBullet"))
            {
                HitPoint.hitPoint -= 1;
            }
        }
    }
}