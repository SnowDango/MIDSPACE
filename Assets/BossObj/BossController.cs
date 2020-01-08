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
        public static int bulletPattern = 1; //　弾のパターンの制御
        public Boolean move = true; //全体的な動きの制御
        public Boolean firstMove = true; //最初の動きをしたかどうか
        public Boolean callChangeBullet = true;

        public static class HitPoint
        {
            public static int hitPoint = 1000; //HitPoint
        }

        // Start is called before the first frame update
        void Start() // 最初に呼び出されるメソッド
        {
        }


        void Update() //呼び出され続けるメソッド　
        {
            BossBulletCreate b = new BossBulletCreate();

            if (firstMove) //最初の動き
            {
                transform.Translate(0, -0.05f, 0);
                if (transform.position.y <= 4.0f) firstMove = false;
            }
            
            if (bulletPattern == 0) //パターンの判定
            {
                BossBulletCreate.twoLineBullet(Time.frameCount, this); //弾の発射メソッドの呼び出し
                BossMoveControl.twoLineMove(this, Time.frameCount); //動きの呼び出し
                if (callChangeBullet)
                {
                    Invoke("changeBulletPattern", 10.0f);
                    callChangeBullet = false;
                }
            }
            else if (bulletPattern == 1)
            {
                BossBulletCreate.circleBullet(Time.frameCount, this); //　円形状に弾を撃つ
                move = false; //動きをやめる
                 if (callChangeBullet)
                 { 
                     Invoke("changeBulletPattern", 10.0f); 
                     callChangeBullet = false;
                 }
            }
            else if (bulletPattern == 2)
            {
                BossBulletCreate.parallelCircleBullet(Time.frameCount, this); //円形状に弾を撃つパート2
                 if (callChangeBullet)
                 { 
                     Invoke("changeBulletPattern", 10.0f); 
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
            }
        }

        void changeBulletPattern()
        {
            System.Random r = new System.Random(1000);
            bulletPattern = Random.Range(0, 3);
            callChangeBullet = true;
        }
    }
}