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

        public GameObject enemyBulletPrefab, enemyLazerPrefab; //　弾のprefab
        public static int bulletPattern; //　弾のパターンの制御
        public static int subBulletPattern;
        public Boolean move; //全体的な動きの制御
        public Boolean firstMove; //最初の動きをしたかどうか
        public Boolean callChangeBullet;
        public GameObject hpSliderPrefab;
        public static class HitPoint
        {
            public static int hitPoint = 1000; //HitPoint
        }

        // Start is called before the first frame update
        void Start() // 最初に呼び出されるメソッド
        {
            GameObject canvas = GameObject.Find("Canvas");
            GameObject slider = Instantiate(hpSliderPrefab, canvas.transform);
            bulletPattern = 1;
            subBulletPattern = 0;
            move = true;
            firstMove = true;
            callChangeBullet = true;
            HitPoint.hitPoint = 1000;
            BossBulletCreate.circleBulletDegrees = 0;
            BossBulletCreate.deathBulletDegrees = 0;
        }
        
        void Update() //呼び出され続けるメソッド　
        {
            BossBulletCreate b = new BossBulletCreate();

            if (firstMove) //最初の動き
            {
                transform.Translate(0, -0.05f, 0);
                if (transform.position.y <= 4.0f) firstMove = false;
            }

            if (HitPoint.hitPoint > 500)
            {
                if (bulletPattern == 0) //パターンの判定
                {
                    BossBulletCreate.twoLineBullet(Time.frameCount, this); //弾の発射メソッドの呼び出し
                    BossMoveControl.twoLineMove(this, Time.frameCount); //動きの呼び出し
                    
                }
                else if (bulletPattern == 1)
                {
                    BossBulletCreate.circleBullet(Time.frameCount, this); //　円形状に弾を撃つ
                    move = false; //動きをやめる
                    
                }
                else if (bulletPattern == 2)
                {
                    BossBulletCreate.parallelCircleBullet(Time.frameCount, this); //円形状に弾を撃つパート2
                    
                }
                
                if (callChangeBullet) {
                    Invoke("changeBulletPattern", 10.0f);
                    callChangeBullet = false;
                }
            }else {
                if (bulletPattern == 0) {
                    if (subBulletPattern == 0) {
                        BossBulletCreate.twoLineBullet(Time.frameCount, this);
                        subBulletPattern = 1;
                    }else if (subBulletPattern == 1) {
                        BossBulletCreate.circleBullet(Time.frameCount, this);
                        subBulletPattern = 2;
                    }else if (subBulletPattern == 2) {
                        BossBulletCreate.parallelCircleBullet(Time.frameCount, this);
                        subBulletPattern = 0;
                    }
                }else if (bulletPattern == 1) {
                    BossBulletCreate.deathBullet(Time.frameCount,this);
                }
                
                BossMoveControl.twoLineMove(this, Time.frameCount);
                
                if (callChangeBullet) {
                    Invoke("changeBulletPatternAlter", 10.0f);
                    callChangeBullet = false;
                }
            }

            if (Time.frameCount % 1000 == bulletPattern)
            {
                BossBulletCreate.fireLaser(this, 5.0f, -3f, 10.0f);
                BossBulletCreate.fireLaser(this, -5.0f, -3f, 10.0f);
            }

        }

        void OnTriggerEnter2D(Collider2D coll) //物理判定に引っかかった場合
        {
            if (coll.gameObject.CompareTag("playerBullet")) //playerのたまに当たった場合
            {
                HitPoint.hitPoint -= 1; // HitPointを−1する
                CheckHitPoint.checkHP(this, HitPoint.hitPoint); // Hpをチェックする
                ScoreCount.scoreCount(); // scoreをカウントするメソッドを呼び出す
                
                if (HitPoint.hitPoint == 500) {
                    bulletPattern = 0;
                    CancelInvoke("changeBulletPattern");
                    callChangeBullet = true;
                }
            }
        }

        void changeBulletPattern()
        {
            System.Random r = new System.Random(1000);
            bulletPattern = Random.Range(0, 3);
            callChangeBullet = true;
        }

        void changeBulletPatternAlter()
        {
            System.Random r = new System.Random(1000);
            bulletPattern = Random.Range(0, 2);
            callChangeBullet = true;
        }
    }
}