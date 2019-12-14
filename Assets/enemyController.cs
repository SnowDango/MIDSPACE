using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class enemyController : MonoBehaviour {

    public Boolean side = true;
    public GameObject enemyBulletPrefab;
    public static int bulletPatarn = 1;
    public Boolean move = true;
    public Boolean firstMove = true;
    public GameObject shot;

    public static class HitPoint {
        public static int hitPoint = 300;
    }

    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame

    public static void updateHP()
    {
        HitPoint.hitPoint -= 3;
    }

    void Update()
    {
        if (firstMove) {
           transform.Translate(0,-0.05f,0);
            if (transform.position.y <= 4.0f) firstMove = false;
        }else {
            if (move)
            {
                if (side)
                {
                    transform.Translate(0.05f, 0, 0);
                }
                else
                {
                    transform.Translate(-0.05f, 0, 0);
                }

                if (transform.position.x >= 2.45)
                {
                    side = false;
                }
                else if (transform.position.x <= -2.45)
                {
                    side = true;
                }


            }

            if (Time.frameCount % 500 == 0)
            {
                System.Random r = new System.Random(1000);
                bulletPatarn = r.Next(2);
            }

            if (bulletPatarn == 0) 
            {
                EnemyBulletCreate.twoLineBullet(Time.frameCount,this);
                move = true;
            }
            else if (bulletPatarn == 1)
            {
                EnemyBulletCreate.circleBullet(Time.frameCount,this);
                move = false;
            } else if (bulletPatarn == 2)
            {
                //EnemyBulletCreate.parallelCircleBullet(Time.frameCount,)
            }
            checkHP();
        }
    }

    public void checkHP() {
        if (HitPoint.hitPoint <= 0) {
            Destroy(this.gameObject);
        }
    }
    
    public double ToRadian(double angle) {
        return (double) (angle * Math.PI / 180);
    }
}
