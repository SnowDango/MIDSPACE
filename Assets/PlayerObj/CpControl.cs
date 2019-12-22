using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct bullet {
	private float x;
	private float y;
	private float z;
}

public class CpControl : MonoBehaviour {

	public class HitPoint {
		public static int hitPoint = 5;
	}

	SpriteRenderer MainSpriteRenderer;
	public Sprite DefaultSprite;
	public Sprite StandbySprite;
	public Sprite LeftSprite;
	public Sprite RightSprite;
	
	public GameObject bulletPrefab;

	public static float CpX;
	public static float CpY;
	
	public bullet bulletPosion = new bullet();
	// Start is called before the first frame update

	void Start() {
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update ()
    {
	    var position = transform.position;
	    CpX = position.x;
	    CpY = position.y;
	    
	    MainSpriteRenderer.sprite = DefaultSprite;

	    if (Input.GetKey (KeyCode.LeftArrow)) {
		    if (position.x >= -6.0f) {
			    MainSpriteRenderer.sprite = LeftSprite;
			    transform.Translate (-0.05f, 0, 0);
		    }
	    }else if (Input.GetKey (KeyCode.RightArrow)) {
		    if (position.x <= 6.0f) {
			    MainSpriteRenderer.sprite = RightSprite;
			    transform.Translate ( 0.05f, 0, 0);
		    }
	    } 
	    if (Input.GetKey(KeyCode.UpArrow)) {
		    if (position.y <= -0.05) {
			    transform.Translate (0,0.05f,0);
		    }
	    }else if (Input.GetKey(KeyCode.DownArrow)) {
		    if (position.y >= -4.55) {
			    MainSpriteRenderer.sprite = StandbySprite;
			    transform.Translate(0,-0.05f,0);
		    }
	    }
	    
	    if (Time.frameCount % 8 == 0 /* && Time.frameCount / 4 <= 1*/) {
		    Instantiate(bulletPrefab, new Vector3(position.x,position.y+0.4f,position.z), Quaternion.identity);
	    }
    }

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.CompareTag("EnemyBullet") ||  coll.gameObject.CompareTag("EnemyObject")) {
			HitPoint.hitPoint -= 1;
			CheckHitPoint.checkHP(this,HitPoint.hitPoint);
		}
	}
}
