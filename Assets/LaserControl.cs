using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControl : MonoBehaviour {
    // Start is called before the first frame update

    private float time;
    private float firstFrameCount;
    
    public void setLaserData(float time)
    {
        this.time = time;
    }
    void Start()
    {
        this.GetComponent<SpriteRenderer>().color = new Color(1.0f,1.0f,1.0f,0.2f);
        Invoke("changeMode",2.0f);
        Invoke("lostObject",time+2.0f);
        firstFrameCount = Time.frameCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (firstFrameCount < Time.frameCount - 920) {
            Destroy(gameObject);
        }
    }

    void changeMode()
    {
        this.GetComponent<SpriteRenderer>().color = new Color(1.0f,1.0f,1.0f,1.0f);
        this.tag = "EnemyBullet";
    }
}
