using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class enemyController : MonoBehaviour
{

    public Boolean side = true;
    public GameObject enemyBulletPrefab;
    public static int bulletPatarn = 1;
    public static int circleBulletDegrees = 0;
    public Boolean move = true;

    public static class HitPoint {
        public static int hitPoint = 300;
    }

    // Start is called before the first frame update
    void Start() {
       
    }

    // Update is called once per frame

    public static void updateHP()
    {
        HitPoint.hitPoint -= 3;
    }

    void Update() {
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
        if (Time.frameCount % 1000 == 0) {
            System.Random r = new System.Random(1000);
            bulletPatarn = r.Next(2);
        }
        
        if (bulletPatarn == 0) {
            twoLineBullet(Time.frameCount);
            move = true;
        }else if (bulletPatarn == 1) {
            circleBullet(Time.frameCount);
            move = false;
        }
        checkHP();
    }

    public void checkHP() {
        if (HitPoint.hitPoint <= 0) {
            Destroy(this.gameObject);
        }
    }

    public void twoLineBullet(double frameCount) {
        if (frameCount % 10 == 0) {
            GameObject shot1 = Instantiate(enemyBulletPrefab,
                new Vector3(transform.position.x + 1.6f, transform.position.y - 1.0f, transform.position.z),
                Quaternion.identity);
            enemyBulletController s = shot1.GetComponent<enemyBulletController>();
            s.bulletData(ToRadian(-90));
            
            GameObject shot2 = Instantiate(enemyBulletPrefab,
                new Vector3(transform.position.x - 1.6f, transform.position.y - 1.0f, transform.position.z),
                Quaternion.identity);
            s = shot2.GetComponent<enemyBulletController>();
            s.bulletData(ToRadian(-90));
        }
    }

    public void circleBullet(double frameCount) {

        if (frameCount % 4 == 0)
        {

            float x1 = (float) (1.6f * Math.Cos(ToRadian(90 + circleBulletDegrees)));
            float y1 = (float) (1.6f * Math.Sin(ToRadian(90 + circleBulletDegrees)));
            float x2 = (float) (1.6f * Math.Cos(ToRadian(-90 + circleBulletDegrees)));
            float y2 = (float) (1.6f * Math.Sin(ToRadian(-90 + circleBulletDegrees)));
            float x3 = (float) (1.6f * Math.Cos(ToRadian(circleBulletDegrees)));
            float y3 = (float) (1.6f * Math.Sin(ToRadian(circleBulletDegrees)));
            float x4 = (float) (1.6f * Math.Cos(ToRadian(-180 + circleBulletDegrees)));
            float y4 = (float) (1.6f * Math.Sin(ToRadian(-180 + circleBulletDegrees)));

            GameObject shot1 = Instantiate(enemyBulletPrefab,
                new Vector3(transform.position.x + x1, transform.position.y + y1, transform.position.z),
                Quaternion.FromToRotation(Vector3.zero, new Vector3(x1, y1)));
            enemyBulletController s = shot1.GetComponent<enemyBulletController>();
            s.bulletData(ToRadian(90 + circleBulletDegrees));

            GameObject shot2 = Instantiate(enemyBulletPrefab,
                new Vector3(transform.position.x + x2, transform.position.y + y2, transform.position.z),
                Quaternion.FromToRotation(Vector3.zero, new Vector3(x2, y2)));
            s = shot2.GetComponent<enemyBulletController>();
            s.bulletData(ToRadian(-90 + circleBulletDegrees));
            
            GameObject shot3 = Instantiate(enemyBulletPrefab,
                new Vector3(transform.position.x + x3, transform.position.y + y3, transform.position.z),
                Quaternion.FromToRotation(Vector3.zero, new Vector3(x3, y3)));
            s = shot3.GetComponent<enemyBulletController>();
            s.bulletData(ToRadian(circleBulletDegrees));
            
            GameObject shot4 = Instantiate(enemyBulletPrefab,
                new Vector3(transform.position.x + x4, transform.position.y + y4, transform.position.z),
                Quaternion.FromToRotation(Vector3.zero, new Vector3(x4, y4)));
            s = shot4.GetComponent<enemyBulletController>();
            s.bulletData(ToRadian(180 + circleBulletDegrees));

            circleBulletDegrees += 10;
        }
    }

    public double ToRadian(double angle) {
        return (double) (angle * Math.PI / 180);
    }
}
